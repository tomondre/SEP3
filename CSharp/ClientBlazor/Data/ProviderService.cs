using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task CreateProvider(Provider provider)
        {
            string providerAsJson = JsonSerializer.Serialize(provider);
            var stringContent = new StringContent(providerAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, stringContent);
            CheckException(httpResponseMessage);
        }

        public async Task<ProviderList> GetAllProviders()
        {
            var httpResponseMessage = await client.GetAsync(uri);
            CheckException(httpResponseMessage);
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

        public async Task EditProvider(Provider provider)
        {
            var json = JsonSerializer.Serialize(provider);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PatchAsync($"{uri}/{provider.Id}", stringContent);
            CheckException(httpResponseMessage);
        }

        public async Task DeleteProvider(Provider provider)
        {
            var httpResponseMessage = await client.DeleteAsync($"{uri}/{provider.Id}");
            CheckException(httpResponseMessage);
        }

        public async Task<ProviderList> GetAllNotApprovedProvidersAsync()
        {
            var httpResponseMessage = await client.GetAsync($"{uri}/?approved=false");
            CheckException(httpResponseMessage);
            var providersAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            ProviderList providers = JsonSerializer.Deserialize<ProviderList>(providersAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return providers;
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