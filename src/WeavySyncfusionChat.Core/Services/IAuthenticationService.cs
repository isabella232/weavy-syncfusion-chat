using System.Threading.Tasks;
using WeavySyncfusionChat.Core.Models;

namespace WeavySyncfusionChat.Core.Services
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn(string username, string password);
        Task<bool> IsAuthenticated();
        Task<User> GetProfile();
        
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRestService _restService;

        public AuthenticationService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<User> GetProfile()
        {
            return await _restService.GetAsync<User>("/api/users/me");
        }

        public async Task<bool> IsAuthenticated()
        {
            // check if user is already authenticated here. For example, store the token in Secure storage or similar.
            // in this demo we just return true
            return await Task.FromResult(true);            
        }

        public async Task<bool> SignIn(string username, string password)
        {

            // here you should sign in user to your host application. If authorized 
            return await Task.FromResult(true);


            
        }
    }
}
