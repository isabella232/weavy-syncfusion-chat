using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        [JsonProperty("thumb")]
        public string ThumbUrl { get; set; }

        public Profile Profile { get; set; }

        public string ThumbUrlFull => $"{Constants.RootUrl}{(ThumbUrl?.Replace("{options}", "64"))}";
    }

    public class Profile
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }

    }
}
