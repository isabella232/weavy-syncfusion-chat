using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class Conversation
    {
        //[PrimaryKey]
        public int Id { get; set; }

        [JsonProperty("is_room")]
        public bool IsRoom { get; set; }
              
        
        [JsonProperty("avatar_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty("excerpt")]
        public string LastMessage { get; set; }

        [JsonProperty("last_message_at")]
        public string LastMessageAt { get; set; }

        
        [JsonProperty("is_read")]
        public bool IsRead { get; set; }

        [JsonProperty("is_pinned")]
        public bool IsPinned { get; set; }

        public string ThumbUrlFull => $"{Constants.RootUrl}{ThumbUrl}";

        public string Title { get; set; }


    }
}
