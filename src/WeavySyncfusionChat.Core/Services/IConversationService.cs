using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeavySyncfusionChat.Core.Models;

namespace WeavySyncfusionChat.Core.Services
{
    public interface IConversationService
    {
        Task<IEnumerable<Conversation>> Get();
        Task<PageOf<Message>> GetMessages(int conversationId, int top, int skip);
        Task SendMessage(int id, string text);
        Task MarkAsRead(int id);
        Task<Conversation> Create(CreateConversationModel model);
    }

    public class ConversationService : IConversationService
    {
        private readonly IRestService _restService;

        public ConversationService(IRestService restService)
        {
            _restService = restService;          
        }

        public async Task<Conversation> Create(CreateConversationModel model)
        {            
            var response = await _restService.PostAsync("/api/conversations", JsonConvert.SerializeObject(model));

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Conversation>(data);
        }

        public async Task<IEnumerable<Conversation>> Get()
        {
            return await _restService.GetAsync<IEnumerable<Conversation>>("/api/conversations");
        }

        public async Task<PageOf<Message>> GetMessages(int conversationId, int top, int skip)
        {
            return await _restService.GetAsync<PageOf<Message>>($"/api/conversations/{conversationId}/messages?top={top}&skip={skip}");
        }

        public async Task MarkAsRead(int conversationId)
        {
            await _restService.PostAsync($"/api/conversations/{conversationId}/read");
        }

        public async Task SendMessage(int conversationId, string text) {
            var json = $"{{ 'text': '{text}'}}";
            var response = await _restService.PostAsync($"/api/conversations/{conversationId}/messages", json);
            var s = await response.Content.ReadAsStringAsync();
        }
    }
}
