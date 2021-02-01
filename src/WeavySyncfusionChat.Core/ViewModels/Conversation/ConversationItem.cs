using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeavySyncfusionChat.Core.ViewModels.Conversation
{
    public class ConversationItem : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private DateTime _lastMessageAt;
        public DateTime LastMessageAt
        {
            get => _lastMessageAt;
            set => SetProperty(ref _lastMessageAt, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        public ImageSource ImageSource => new UriImageSource() { Uri = new Uri(ThumbUrl) };



        private string _thumbUrl;
        public string ThumbUrl
        {
            get => _thumbUrl;
            set => SetProperty(ref _thumbUrl, value);
        }

        public string ConversationTitle { get; internal set; }

        private string _lastMessageByName;
        public string LastMessageByName {
            get => _lastMessageByName;
            set => SetProperty(ref _lastMessageByName, value);
        }

        private bool _isRead;
        public bool IsRead
        {
            get => _isRead;
            set => SetProperty(ref _isRead, value);
        }

        public bool IsRoom { get; internal set; }
    }
}
