using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private HttpClient client;
        private string uri;

        public ExperienceService()
        {
            client = new HttpClient();
            uri = "https://localhost:5001/Experiences";
        }

        public Task<Experience> AddExperienceAsync(Experience experience)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}/{provider}");
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }
    }
}