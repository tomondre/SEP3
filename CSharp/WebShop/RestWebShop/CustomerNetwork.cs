using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.RestWebShop
{
    public class CustomerNetwork : ICustomerNetwork
    {
        private HttpClient client;
        private string uri;

        public CustomerNetwork(HttpClient client)
        {
            this.client = client;
            uri = "https://localhost:5001/Customers";
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            var stringContent = new StringContent(customerAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, stringContent);
            CheckException(httpResponseMessage);
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Customer>(json,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return deserialize;
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