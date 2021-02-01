using WeavySyncfusionChat.Core.Models;

namespace WeavySyncfusionChat.Core
{
    public class Constants
    {
        // feel free to try out this chat app against the test site https://chat-demo.weavycloud.com. We do recommend that you set up your own Weavy though. Take a look at https://docs.weavy.com for more information..
        public static string RootUrl = "https://chat-demo.weavycloud.com";

        // the Client ID (Issuer) for the Weavy Client. This example using a test client for the test app https://demo-chat.weavycloud.com. You should create a new Client under Manage -> Clients in your own Weavy site that you have set up
        public static string ClientId = "75d684b1-375d-4919-8d4f-f4c45954df4d";

        // the Client Secret for the Weavy Client. This example using a test client for the test app https://demo-chat.weavycloud.com. You should create a new Client under Manage -> Clients in your own Weavy site that you have set up
        public static string ClientSecret = "e94biFOUvuClVvXXOKV[t3hJP.Vft@R[";

        public static User Me { get; internal set; }
    }
}
