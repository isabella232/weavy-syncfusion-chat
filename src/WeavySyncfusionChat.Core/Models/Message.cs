using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class Message
    {
        public Message()
        {
            Attachments = new List<int>();
        }

        public int Id { get; set; }

        public int Conversation { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }

        [JsonProperty("created_at")]
        public virtual DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public virtual Member CreatedBy { get; set; }

        public List<int> Attachments { get; set; }
    }
}
