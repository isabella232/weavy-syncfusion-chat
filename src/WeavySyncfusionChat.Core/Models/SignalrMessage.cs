using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class SignalrMessage
    {
        public SignalrMessage()
        {
            Attachments = new List<int>();
        }

        public int Id { get; set; }

        public int Conversation { get; set; }
        public string Text => Html;
        public string Html { get; set; }


        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("createdBy")]
        public Member CreatedBy { get; set; }
                
        public int CreatedById => CreatedBy.Id;
                
        public string CreatedByName => CreatedBy.Name;

        public string CreatedByThumbFull => CreatedBy.ThumbUrlFull;

        public virtual List<int> Attachments { get; set; }

        public IEnumerable<int> AttachmentsIds => Attachments.Select(x => x);
    }
}
