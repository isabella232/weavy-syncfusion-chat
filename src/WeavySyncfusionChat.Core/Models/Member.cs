using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        [JsonProperty("thumb")]
        public string ThumbUrl { get; set; }

        [JsonProperty("delivered_at")]
        public DateTime DeliveredAt { get; set; }

        [JsonProperty("read_at")]
        public DateTime ReadAt { get; set; }

        public Precence Precence { get; set; }

        public string ThumbUrlFull => $"{Constants.RootUrl}{(ThumbUrl.Replace("{options}", "64"))}";
    }

    public enum Precence
    {
        Away = 0,
        Active = 1
    }
}
