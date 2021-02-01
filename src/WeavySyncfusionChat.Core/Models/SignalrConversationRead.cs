using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Models
{
    public class SignalrConversationRead
    {
        [JsonProperty("user")]
        public Member User { get; set; }

        [JsonProperty("conversation")]
        public Conversation Conversation { get; set; }
    }
}
