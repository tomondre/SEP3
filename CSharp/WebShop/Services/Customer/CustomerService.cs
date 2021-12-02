using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebShop.Data.Authentication;

namespace WebShop.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private HttpClient client;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private string uri;
        private readonly ProtectedSessionStorage sessionStorage;
        
        public CustomerService(HttpClient client, AuthenticationStateProvider authenticationStateProvider, ProtectedSessionStorage sessionStorage )
        {
            this.client = client;
            this.sessionStorage = sessionStorage;
            this.authenticationStateProvider = authenticationStateProvider;
            uri = "https://localhost:5001/Customers";
        }

        public async Task CreateCustomerAsync(GrpcFileGeneration.Models.Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            var stringContent = new StringContent(customerAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, stringContent);
            
            CheckException(httpResponseMessage);
            
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<GrpcFileGeneration.Models.Customer>(json,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            await ((CurrentAuthenticationStateProvider) authenticationStateProvider).ValidateUser(deserialize);
        }

        public async Task<GrpcFileGeneration.Models.Customer> GetCustomerByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/{id}");
            CheckException(response);
            var objAsJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GrpcFileGeneration.Models.Customer>(objAsJson, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public async Task<GrpcFileGeneration.Models.Customer> EditCustomerAsync(GrpcFileGeneration.Models.Customer customer)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Patch, $"{uri}/{customer.Id}");
            var json = JsonSerializer.Serialize(customer);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
            var objAsJson = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GrpcFileGeneration.Models.Customer>(objAsJson, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.ReasonPhrase} ");
            }
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
    }
}