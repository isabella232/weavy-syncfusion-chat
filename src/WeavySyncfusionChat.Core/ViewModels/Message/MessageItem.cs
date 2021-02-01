using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeavySyncfusionChat.Core.Models;

namespace WeavySyncfusionChat.Core.ViewModels.Message
{
    public class MessageItem : BaseViewModel
    {
        public MessageItem()
        {
            Attachments = new List<int>();
        }
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string Text { get; internal set; }
        public string Html { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public List<int> Attachments { get; internal set; }
        public Member CreatedBy { get; internal set; }
        public bool Me { get; internal set; }

        public List<string> AttachmentUrls => Attachments.Select(x => $"{Constants.RootUrl}/attachments/{x}/file-512x512.jpg").ToList();

        public bool HasAttachments => Attachments.Count() > 0;
    }
}
