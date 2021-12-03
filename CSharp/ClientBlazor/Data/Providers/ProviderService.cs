using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientBlazor.Data.Authentication;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ClientBlazor.Data.Providers
{
    public class ProviderService : IProviderService
    {
        private HttpClient client;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ProtectedSessionStorage sessionStorage;
        private string uri;

        public ProviderService(HttpClient client, AuthenticationStateProvider authenticationStateProvider,
            ProtectedSessionStorage sessionStorage)
        {
            this.client = client;
            this.authenticationStateProvider = authenticationStateProvider;
            this.sessionStorage = sessionStorage;
            uri = "https://localhost:5001/Provider";
        }

        public async Task CreateProvider(Provider provider)
        {
            string providerAsJson = JsonSerializer.Serialize(provider);
            var stringContent = new StringContent(providerAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, stringContent);
            CheckException(httpResponseMessage);

            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();

            var user = JsonSerializer.Deserialize<User>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await ((CurrentAuthenticationStateProvider) authenticationStateProvider).ValidateUser(user);
        }

        public async Task<Page<ProviderList>> GetAllProviders(int page)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Get, $"{uri}/?approved=true&page={page}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
            var providersAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            var providers = JsonSerializer.Deserialize<Page<ProviderList>>(providersAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return providers;
        }

        public async Task<Provider> GetProviderById(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/{id}");
            CheckException(response);
            var objAsJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Provider>(objAsJson, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public async Task<Provider> EditProvider(Provider provider)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Patch, $"{uri}/{provider.Id}");
            var json = JsonSerializer.Serialize(provider);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
            var objAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Provider>(objAsJson, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        }

        public async Task DeleteProvider(Provider provider)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Delete, $"{uri}/{provider.Id}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
        }

        public async Task<Page<ProviderList>> GetAllNotApprovedProvidersAsync(int page)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Get, $"{uri}/?approved=false&page={page}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
            var providersAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            var providers = JsonSerializer.Deserialize<Page<ProviderList>>(providersAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return providers;
        }

        public async Task<Page<ProviderList>> GetAllProvidersByNameAsync(string name, int page)
        {
            var httpRequestMessage = await GetHttpRequest(HttpMethod.Get, $"{uri}?approved=true&name={name}&page={page}");
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            
            CheckException(httpResponseMessage);
            
            var providersAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            var providers = JsonSerializer.Deserialize<Page<ProviderList>>(providersAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return providers;
        }

        private async Task<HttpRequestMessage> GetHttpRequest(HttpMethod method, string uri)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            var token = await sessionStorage.GetAsync<string>("token");
            if (token.Success)
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }
            //TODO add exception
            return httpRequestMessage;
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