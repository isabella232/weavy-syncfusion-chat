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

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("thumb")]
        public string ThumbUrl { get; set; }

        [JsonProperty("last_message")]
        public Message LastMessage { get; set; }

        public IEnumerable<Member> Members { get; set; }

        [JsonProperty("is_read")]
        public bool IsRead { get; set; }

        [JsonProperty("is_pinned")]
        public bool IsPinned { get; set; }

        public string ThumbUrlFull => $"{Constants.RootUrl}{(ThumbUrl.Replace("{options}", "64"))}";

        public string ConversationTitle => IsRoom ? Name ?? string.Join(", ", Members.Select(x => x.Name)) : Members.FirstOrDefault(x => x.Id != Constants.Me.Id)?.Name;


    }
}
