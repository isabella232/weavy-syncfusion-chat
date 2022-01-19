using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using WeavySyncfusionChat.Core.Models;
using WeavySyncfusionChat.Core.Services;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.ViewModels.Conversation
{
    public class NewConversationViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IConversationService _conversationService;
        private readonly IMvxNavigationService _navigationService;
        private bool _isAdding;

        private ObservableCollection<UserResultModel> _resultList;
        public ObservableCollection<UserResultModel> ResultList
        {
            get => _resultList;
            set => SetProperty(ref _resultList, value);
        }


        private ObservableCollection<object> _selectedUsers;
        public ObservableCollection<object> SelectedUsers
        {
            get => _selectedUsers;
            set => SetProperty(ref _selectedUsers, value);
        }

        private string _roomName;
        public string RoomName
        {
            get => _roomName;
            set => SetProperty(ref _roomName, value);
        }

        private Command _addConversationCommand;
        public Command AddConversationCommand
        {
            get => _addConversationCommand;
            set => SetProperty(ref _addConversationCommand, value);
        }

        public NewConversationViewModel(IUserService userService, IConversationService conversationService, IMvxNavigationService navigationService)
        {
            _userService = userService;
            _conversationService = conversationService;
            _navigationService = navigationService;
            _isAdding = false;

            ResultList = new ObservableCollection<UserResultModel>();

            AddConversationCommand = new Command<object>(execute: async (o) => {
                _isAdding = true;                
                var conversation = await _conversationService.Create(new CreateConversationModel {
                    Name = _roomName,
                    Members = _selectedUsers.Select(x => ((UserResultModel)x).Id).ToList()                    
                });

                if(conversation != null)
                {
                    MessagingCenter.Send<GenericMessageSender, ConversationItem>(GenericMessageSender.Instance, "OPEN_CONVERSATION", new ConversationItem { Id = conversation.Id, ConversationTitle = conversation.Title });                    
                    await _navigationService.Close(this);
                }
                _isAdding = false;
            },
            canExecute: (o) =>
            {
                return !_isAdding;
            });
        }

        public async Task LoadResultsAsync(string searchQuery)
        {
            try
            {
                //Get new search results and add to source
                var results = await _userService.Search(searchQuery);
                if (results == null)
                { return; }
                foreach (var result in results.Data)
                {
                    var model = new UserResultModel
                    {
                        Id = result.Id,
                        Name = result.Profile?.Name ?? result.Username ?? result.Email                        
                    };

                    if (!ResultList.Any(x => x.Id == model.Id))
                    {
                        ResultList.Add(model);
                    }
                    
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
