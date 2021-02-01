using System;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class SignalrMessage : Message
    {
        [JsonProperty("createdAt")]
        public override DateTime CreatedAt { get; set; }

        [JsonProperty("createdBy")]
        public override Member CreatedBy { get; set; }
    }
}
