using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientBlazor.Data.Cache;
using ClientBlazor.Models;
using GrpcFileGeneration.Models;
using Order = ClientBlazor.Models.Orders.Order;

namespace ClientBlazor.Data.Orders
{
    public class OrderService : IOrderService
    {
        private HttpClient client;
        private readonly ICacheService cacheService;
        private string url = "https://localhost:5001/";
        
        public OrderService(HttpClient client, ICacheService cacheService)
        {
            this.client = client;
            this.cacheService = cacheService;
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

        public async Task<Page<ProvidersVoucherList>> GetAllProviderVouchersAsync(int page)
        {
            var cachedUserAsync = await cacheService.GetCachedUserAsync();
            var httpResponseMessage = await client.GetAsync($"{url}providers/{cachedUserAsync.Id}/vouchers?page={page}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var orderList = JsonSerializer.Deserialize<Page<ProvidersVoucherList>>(readAsStringAsync, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
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