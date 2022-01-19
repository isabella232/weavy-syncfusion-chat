using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class Message
    {
        public Message()
        {
            Attachments = new List<Attachment>();
        }

        public int Id { get; set; }

        public int Conversation { get; set; }
        public string Text => Html;
        public string Html { get; set; }

        [JsonProperty("created_at")]
        public virtual DateTime CreatedAt { get; set; }

        [JsonProperty("created_by_id")]
        public virtual int CreatedById { get; set; }

        [JsonProperty("created_by")]
        public virtual string CreatedByName { get; set; }

        [JsonProperty("created_by_thumb")]
        public virtual string CreatedByThumb { get; set; }


        public virtual string CreatedByThumbFull => $"{Constants.RootUrl}{CreatedByThumb}";

        public virtual List<Attachment> Attachments { get; set; }

        public IEnumerable<int> AttachmentsIds => Attachments.Select(x => x.Id);
    }
}
