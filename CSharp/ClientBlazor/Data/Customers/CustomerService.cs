using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ClientBlazor.Data.Customers
{
    public class CustomerService : ICustomerService
    {
        private HttpClient client;
        private string uri;
        private readonly ProtectedSessionStorage sessionStorage;

        public CustomerService()
        {
            client = new HttpClient();
            uri = "https://localhost:5001/Customers";
        }

        public async Task<CustomerList> GetAllCustomers()
        {
            var httpRequestMessage = await GetHttpRequest(HttpMethod.Get, uri);
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            
            CheckException(httpResponseMessage);

            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var customerList = JsonSerializer.Deserialize<CustomerList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return customerList;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            var httpRequestMessage = await GetHttpRequest(HttpMethod.Delete, $"{uri}/{customer.Id}");
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            
            CheckException(httpResponseMessage);
        }
        
        private async Task<HttpRequestMessage> GetHttpRequest(HttpMethod method, string uri)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            // var token = await sessionStorage.GetAsync<string>("token");
            // if (token.Success)
            // {
            //     httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            // }
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