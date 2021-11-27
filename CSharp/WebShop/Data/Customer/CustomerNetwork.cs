using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Authorization;
using WebShop.Data.Authentication;

namespace WebShop.Data.Customer
{
    public class CustomerNetwork : ICustomerNetwork
    {
        private HttpClient client;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private string uri;

        public CustomerNetwork(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            this.client = client;
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

        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.ReasonPhrase} ");
            }
        }
    }
}