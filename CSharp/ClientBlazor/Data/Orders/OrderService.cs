using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models.Orders;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace ClientBlazor.Data.Orders
{
    public class OrderService : IOrderService
    {
        private HttpClient client;
        private string url = "https://localhost:5001/";
        
        public OrderService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{url}orders/{id}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Order>(readAsStringAsync,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return deserialize;
        }

        public async Task<OrderList> GetCustomerOrdersAsync(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{url}customers/{id}/orders");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var orderList = JsonSerializer.Deserialize<OrderList>(readAsStringAsync, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return orderList;
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