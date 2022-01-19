using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNet.SignalR.Client;
using MvvmCross.Navigation;
using Newtonsoft.Json;
using Syncfusion.XForms.Chat;
using WeavySyncfusionChat.Core.Models;
using WeavySyncfusionChat.Core.Services;
using WeavySyncfusionChat.Core.ViewModels.Conversation;
using Xamarin.Forms;

[assembly: MvxNavigation(typeof(ConversationViewModel), @"mvx://conversation/\?id=(?<id>[A-Z0-9]{32})$")]
namespace WeavySyncfusionChat.Core.ViewModels.Conversation
{
    public class ConversationViewModel : BaseViewModel<ConversationItem>
    {
        private ConversationItem _currentConversation;
        private readonly IConversationService _conversationService;
        private readonly IHubService _hubService;
        private int _skip = 0;
        private bool _canLoadMore = false;
        private bool _isVisible;

        public ConversationViewModel(IConversationService conversationService, IHubService hubService)
        {
            _conversationService = conversationService;
            _hubService = hubService;
            Messages = new ObservableCollection<object>();

            LoadMoreCommand = new Command<object>(execute: (o) =>
            {
                Task.Run(async () => await LoadMessages(clear: false, skip: _skip)).Wait();
            },
            canExecute: (o) =>
            {
                return _canLoadMore;
            });

            SendMessageCommand = new Command(execute: async (args) =>
            {
                var arguments = (args as SendMessageEventArgs);

                // the message is inserted from the signalr realtime hub, so we can set handled to true here.
                arguments.Handled = true;

                await SendMessage(arguments);

                MessagingCenter.Send<GenericMessageSender>(GenericMessageSender.Instance, "CLEAR_EDITOR");
            },
            canExecute: (args) =>
            {
                return true;
            });
        }

        private async Task SendMessage(SendMessageEventArgs arguments)
        {
            var message = arguments.Message;
            await _conversationService.SendMessage(Id, message.Text);
        }

        public override void Prepare(ConversationItem conversation)
        {
            _currentConversation = conversation;
            _currentUser = new Author { Name = Constants.Me.Profile.Name, Avatar = Constants.Me.ThumbUrlFull };
            _skip = 0;

            Id = _currentConversation.Id;
            Title = _currentConversation.ConversationTitle;

            Task.Run(async () => await LoadMessages(clear: true, skip: _skip)).Wait();
            Task.Run(async () => await _conversationService.MarkAsRead(Id)).Wait();
        }

        private List<IMessage> CreateSyncfusionMessages(Models.SignalrMessage message)
        {
            return CreateSyncfusionMessages(message.CreatedById, message.CreatedByName, message.CreatedAt, message.CreatedByThumbFull, message.AttachmentsIds, message.Text);
        }

        private List<IMessage> CreateSyncfusionMessages(Models.Message message)
        {
            return CreateSyncfusionMessages(message.CreatedById, message.CreatedByName, message.CreatedAt, message.CreatedByThumbFull, message.AttachmentsIds, message.Text);
        }

        private List<IMessage> CreateSyncfusionMessages(int createdById, string createdByName, DateTime createdAt, string createdByThumbFull, IEnumerable<int> attachmentsIds, string text)
        {

            var author = (createdById == Constants.Me.Id) ? _currentUser : new Author { Name = createdByName, Avatar = createdByThumbFull.Replace("{options}", "64") };
            var messages = new List<IMessage>();

            if (attachmentsIds.Any())
            {
                // create the first image message
                messages.Add(new ImageMessage()
                {
                    Text = text,
                    Source = $"{Constants.RootUrl}/attachments/{attachmentsIds.First().ToString()}/attachment-512.png",
                    DateTime = createdAt,
                    Author = author,
                });


                // if more attachments, create the image messages
                if (attachmentsIds.Count() > 1)
                {
                    foreach (var attachment in attachmentsIds.Skip(1))
                    {
                        messages.Add(new ImageMessage()
                        {
                            Text = "",
                            Source = $"{Constants.RootUrl}/attachments/{attachment}/attachment-512.png",
                            DateTime = createdAt,
                            Author = author,
                        });
                    }
                }
            }
            else
            {
                messages.Add(new TextMessage
                {
                    Text = text,
                    DateTime = createdAt,
                    Author = author
                });
            }
            return messages;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            _isVisible = true;

            _proxyEvent = _hubService.Proxy.On<string, string>("eventReceived", (type, data) =>
            {
                switch (type)
                {
                    case "typing.weavy":
                        var typing = JsonConvert.DeserializeObject<SignalrTyping>(data);
                        if (typing.Conversation.Equals(Id) && typing.User.Id != Constants.Me.Id)
                        {
                            TypingIndicator = new ChatTypingIndicator();
                            TypingIndicator.Authors.Add(new Author() { Name = typing.User.Username });
                            TypingIndicator.AvatarViewType = AvatarViewType.Text;
                            TypingIndicator.Text = $"{typing.User.Username} is typing...";
                            ShowTypingIndicator = true;

                            Task.Factory.StartNew(() =>
                            {
                                Thread.Sleep(4000);
                                ShowTypingIndicator = false;
                            });
                        }
                        break;
                    case "message-inserted.weavy":
                        var message = JsonConvert.DeserializeObject<SignalrMessage>(data);
                        if (message.Conversation.Equals(Id))
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                ShowTypingIndicator = false;
                                var addedMessages = CreateSyncfusionMessages(message);
                                addedMessages.Reverse();
                                foreach (var addedMessage in addedMessages)
                                {
                                    Messages.Add(addedMessage);
                                }

                                if (_isVisible)
                                {
                                    Task.Run(async () => await _conversationService.MarkAsRead(Id)).Wait();
                                }

                            });

                        }
                        break;
                    default:
                        break;
                }
            });
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();

            _isVisible = false;
            _proxyEvent.Dispose();
        }


        #region Binding Props
        private ObservableCollection<object> _messages;
        public ObservableCollection<object> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        private Author _currentUser;
        public Author CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _showTypingIndicator;
        public bool ShowTypingIndicator
        {
            get => _showTypingIndicator;
            set => SetProperty(ref _showTypingIndicator, value);
        }

        private ChatTypingIndicator _typingIndicator;
        public ChatTypingIndicator TypingIndicator
        {
            get => _typingIndicator;
            set => SetProperty(ref _typingIndicator, value);
        }

        private ICommand _sendMessageCommand;
        public ICommand SendMessageCommand
        {
            get => _sendMessageCommand;
            set => SetProperty(ref _sendMessageCommand, value);
        }

        private ICommand _loadMoreCommand;
        private IDisposable _proxyEvent;

        public ICommand LoadMoreCommand
        {
            get => _loadMoreCommand;
            set => SetProperty(ref _loadMoreCommand, value);
        }
        #endregion

        private async Task LoadMessages(bool clear, bool addBefore = false, int top = 10, int skip = 0)
        {

            try
            {
                IsBusy = true;

                if (clear)
                {
                    Messages.Clear();
                }

                var messages = await _conversationService.GetMessages(Id, top, skip);

                if (messages != null && messages.Data != null)
                {
                    foreach (var message in messages.Data.Reverse())
                    {
                        var isByMe = message.CreatedById == Constants.Me.Id;
                        var newMessages = CreateSyncfusionMessages(message);

                        foreach (var addedMessage in newMessages)
                        {
                            if (addBefore)
                            {
                                Messages.Insert(0, addedMessage);
                            }
                            else
                            {
                                Messages.Add(addedMessage);
                            }
                        }
                    }

                    _skip += top;

                }

                // check if there are more messages
                _canLoadMore = messages.Next != null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
