using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using RiskFirst.Hateoas.Models;

namespace ClientBlazor.Data
{
    public class ProviderService : IProviderService
    {
        private HttpClient client;
        private IHandShakeService handShakeService;
        private Dictionary<string,Link> links;

        public ProviderService(HttpClient client, IHandShakeService handShakeService)
        {
            this.client = client;
            this.handShakeService = handShakeService;
        }

        public async Task CreateProvider(Provider provider)
        {
            string uri = links[LinkNames.create.ToString()].Href;
            string providerAsJson = JsonSerializer.Serialize(provider);
            var stringContent = new StringContent(providerAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, stringContent);
            Console.WriteLine(httpResponseMessage.StatusCode);
            CheckException(httpResponseMessage);
        }

        public async Task<ProviderList> GetAllProviders()
        {
            var handShakeLink = handShakeService.HandShake.Links["allProviders"].Href;
            var httpResponseMessage = await client.GetAsync(handShakeLink);
            var providersAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            ProviderList providers = JsonSerializer.Deserialize<ProviderList>(providersAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            links = providers?.Links;
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
        
        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.ReasonPhrase} ");
            }
        }
    }
}