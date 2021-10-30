using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data
{
    public class ProviderService : IProviderService
    {
        private HttpClient client;
        private string uri;

        public ProviderService(HttpClient client)
        {
            this.client = client;
            uri = "https://localhost:5001/Provider";
        }


        public Task CreateProvider(Provider provider)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProviderList> GetAllProviders()
        {
            var httpResponseMessage = await client.GetAsync(uri);
            var providersAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            ProviderList providers = JsonSerializer.Deserialize<ProviderList>(providersAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return providers;
        }

        public Task<Provider> GetProviderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditProvider(Provider provider)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProvider(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}