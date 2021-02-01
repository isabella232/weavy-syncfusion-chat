using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeavySyncfusionChat.Core.Services
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string resource);

        Task<HttpResponseMessage> PostAsync(string resource, string jsonData = "");
    }

    public class RestService : IRestService
    {
        private readonly ITokenService _tokenService;        
        private HttpClient _client;
        
        public RestService(ITokenService tokenService)
        {
            _tokenService = tokenService;            
            _client = new HttpClient()
            {
                BaseAddress = new Uri(Constants.RootUrl)
            };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GenerateToken());
        }   

        /// <summary>
        /// Generic Get request
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <param name="resource">the endpint to call</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string resource)
        {
            var response = await _client.GetAsync(resource);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Post request
        /// </summary>
        /// <param name="resource">the rndpoint to call</param>
        /// <param name="jsonData">the data to send</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync(string resource, string jsonData = "")
        {
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await _client.PostAsync(resource, content);
        }

    }
}
