using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using WeavySyncfusionChat.Core.Models;
using WeavySyncfusionChat.Core.Services;
using WeavySyncfusionChat.Core.ViewModels.Conversation;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IConversationService _conversationService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IHubService _hubService;
        private readonly IAuthenticationService _authenticationService;
                        
        public HomeViewModel(IConversationService conversationService,
            IMvxNavigationService navigationService,
            IHubService hubService,
            IAuthenticationService authenticationService)
        {
            _conversationService = conversationService;
            _navigationService = navigationService;
            _hubService = hubService;
            _authenticationService = authenticationService;
            List = new ObservableCollection<ConversationItem>();
            TappedCommand = new Command<object>(SelectItem);
            NewConversationCommand = new Command(NewConversation);
            RefreshConversationsCommand = new MvxAsyncCommand(RefreshConversations);
        }

        private void SelectItem(object selected)
        {
            var conversation = ((Syncfusion.ListView.XForms.ItemTappedEventArgs)selected).ItemData as ConversationItem;
            _navigationService.Navigate<ConversationViewModel, ConversationItem>(conversation);
        }

        private void NewConversation()
        {
            _navigationService.Navigate<NewConversationViewModel>();
        }

        public Command<object> TappedCommand { get; set; }
        public Command NewConversationCommand { get; set; }

        public MvxAsyncCommand RefreshConversationsCommand { get; set; }


        private ObservableCollection<ConversationItem> _list;
        public ObservableCollection<ConversationItem> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get => _isEmpty;
            set => SetProperty(ref _isEmpty, value);
        }

        public override void Prepare() {

            base.Prepare();

            MessagingCenter.Subscribe<GenericMessageSender, ConversationItem>(this, "OPEN_CONVERSATION", (obj, conversation) =>
            {
                _navigationService.Navigate<ConversationViewModel, ConversationItem>(conversation);
            });


            var me = Task.Run(async () => await _authenticationService.GetProfile()).Result;

            Constants.Me = me;

            // connect to signalr hub
            Task.Run(async () => await _hubService.Connect()).Wait();

            // load conversation list
            Task.Run(async () => await LoadConversations()).Wait();

            _hubService.Proxy.On<string, string>("eventReceived", (type, data) =>
            {
                switch (type)
                {
                    case "message-inserted.weavy":
                        var message = JsonConvert.DeserializeObject<SignalrMessage>(data);

                        var conversation = List.FirstOrDefault(x => x.Id == message.Conversation);

                        if (conversation != null)
                        {
                            conversation.Description = message.Text;
                            conversation.LastMessageAt = message.CreatedAt;
                            conversation.IsRead = false;
                            conversation.LastMessageByName = message.CreatedBy.Id == Constants.Me.Id ? "Me: " : (conversation.IsRoom ? $"{message.CreatedBy.Name.Split(' ')[0]}: " : "");
                        }
                        
                        break;
                    case "conversation-read.weavy":
                        var read = JsonConvert.DeserializeObject<SignalrConversationRead>(data);

                        if(read.User.Id == Constants.Me.Id)
                        {
                            var existingConversation = List.FirstOrDefault(x => x.Id == read.Conversation.Id);

                            if (existingConversation != null)
                            {
                                existingConversation.IsRead = true;
                            }
                        }
                        
                        break;
                    default:
                        break;
                }
            });
        }

        private async Task RefreshConversations()
        {
            await LoadConversations();
        }

        private async Task LoadConversations()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsEmpty = false;

            try
            {
                List.Clear();

                var conversations = await _conversationService.Get();

                if(conversations != null && conversations.Count() > 0)
                {
                    foreach (var conversation in conversations)
                    {
                        List.Add(new ConversationItem
                        {
                            Id = conversation.Id,
                            Name = conversation.Name,
                            IsRoom = conversation.IsRoom,
                            IsRead = conversation.IsRead,
                            ConversationTitle = conversation.ConversationTitle,
                            LastMessageAt = conversation.LastMessage?.CreatedAt ?? DateTime.Now,
                            LastMessageByName = conversation.LastMessage?.CreatedBy.Id == Constants.Me.Id ? "Me: " : (conversation.IsRoom ? $"{conversation.LastMessage?.CreatedBy.Name.Split(' ')[0]}: " : ""),
                            Description = conversation.LastMessage?.Text,
                            ThumbUrl = conversation.ThumbUrlFull
                        });
                    }
                }
                else
                {
                    IsEmpty = true;
                }
                
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
