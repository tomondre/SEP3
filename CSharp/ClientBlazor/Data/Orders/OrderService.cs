using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientBlazor.Models;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Orders;
using Order = ClientBlazor.Models.Orders.Order;

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

        public async Task<Page<OrderList>> GetCustomerOrdersAsync(int id, int page)
        {
            var httpResponseMessage = await client.GetAsync($"{url}customers/{id}/orders?page={page}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var orderList = JsonSerializer.Deserialize<Page<OrderList>>(readAsStringAsync, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return orderList;
        }

        public async Task<ProvidersVoucherList> GetAllProviderVouchersAsync(int? id)
        {
            var httpResponseMessage = await client.GetAsync($"{url}providers/{id}/vouchers");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var orderList = JsonSerializer.Deserialize<ProvidersVoucherList>(readAsStringAsync, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
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