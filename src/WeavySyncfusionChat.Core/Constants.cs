using WeavySyncfusionChat.Core.Models;

namespace WeavySyncfusionChat.Core
{
    public class Constants
    {
        // feel free to try out this chat app against the test site https://showcase.weavycloud.com. We do recommend that you set up your own Weavy though. Take a look at https://docs.weavy.com for more information..
        public static string RootUrl = "https://showcase.weavycloud.com";

        // the Client ID (Issuer) for the Weavy Client. If you are testing against a local Weavy installation ,you should create a new Client under Manage -> Clients
        public static string ClientId = "";

        // the Client Secret for the Weavy Client. If you are testing against a local Weavy installation ,you should create a new Client under Manage -> Clients
        public static string ClientSecret = "";

        public static User Me { get; internal set; }
    }
}
