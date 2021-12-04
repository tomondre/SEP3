using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Orders;
using Stripe;
using OrderStripe = Stripe.Order;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace WebShop.Services.Orders
{
    public class OrderService : IOrderService
    {
        private HttpClient client;
        private string secretKey = "sk_test_51JyZa3HP6RYbC1HUXv6ohA4Hz6PiePRCQUdo0R6xGXDqvnEKc8E95CobkUpAj12nvHqyuhASAMtEsxfDSyHKkh3S00KY0zYi2B";
        private string url = "https://localhost:5001/";
        
        public OrderService(HttpClient client)
        {
            this.client = client;
            StripeConfiguration.ApiKey = secretKey;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            //Step 1 - CreatePaymentMethod from stripe and receive payment id
            var options = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = order.CreditCard.Number,
                    ExpMonth = order.CreditCard.Month,
                    ExpYear = order.CreditCard.Year,
                    Cvc = order.CreditCard.Cvv
                }
            };
            var paymentMethodService = new PaymentMethodService();
            var paymentMethod = await paymentMethodService.CreateAsync(options);
            
            //Step 2 - Remove credit card information for safety
            order.RemoveCreditCardInformation();

            //Step 3 - Add Payment method id to order
            order.PaymentId = paymentMethod.Id;
            
            //Step 4 - Send order to rest api
            var serialize = JsonSerializer.Serialize(order);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync =  await client.PostAsync($"{url}orders", stringContent);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            
            //Step 5 - Check exception
            CheckException(postAsync);
            
            //Step 6 - Deserialize
            var deserialize = JsonSerializer.Deserialize<Order>(readAsStringAsync, new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            //Step 7 - Return Id of created order
            return deserialize.Id;
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

        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.ReasonPhrase} ");
            }
        }
    }
}