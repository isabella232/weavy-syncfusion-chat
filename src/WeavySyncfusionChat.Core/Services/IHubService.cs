using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace WeavySyncfusionChat.Core.Services
{
    public interface IHubService
    {
        Task Connect();
                
        IHubProxy Proxy { get; set; }
    }

    public class HubService : IHubService
    {
        private HubConnection _hubConnection;
        private readonly ITokenService _tokenService;

        public IHubProxy Proxy { get; set; }

        public HubService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Connect to the Weavy SignalR hub
        /// </summary>
        /// <returns></returns>
        public async Task Connect()
        {
            // create a connection
            _hubConnection = new HubConnection(Constants.RootUrl)
            {
                TraceLevel = TraceLevels.All,
                TraceWriter = Console.Out                
            };

            // add a jwt token for signalr hub authentication
            _hubConnection.Headers.Add(new KeyValuePair<string, string>("Authorization", $"Bearer {_tokenService.GenerateToken()}"));

            // create the proxy
            Proxy = _hubConnection.CreateHubProxy("rtm");

            // connect
            await _hubConnection.Start();

        }

    }
}
