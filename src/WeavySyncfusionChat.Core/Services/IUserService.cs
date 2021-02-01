using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeavySyncfusionChat.Core.Models;

namespace WeavySyncfusionChat.Core.Services
{
    public interface IUserService
    {
        Task<PageOf<User>> Search(string q);
    }

    public class UserService : IUserService
    {
        private readonly IRestService _restService;

        public UserService(IRestService restService)
        {
            _restService = restService;
        }
        public async Task<PageOf<User>> Search(string q)
        {
            return await _restService.GetAsync<PageOf<User>>($"/api/users?q={q}");
        }
    }
}
