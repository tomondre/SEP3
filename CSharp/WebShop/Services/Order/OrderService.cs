using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Stripe;

namespace WebShop.Services.Order
{
    public class OrderService : IOrderService
    {
        private HttpClient client;
        private string secretKey = "sk_test_51JyZa3HP6RYbC1HUXv6ohA4Hz6PiePRCQUdo0R6xGXDqvnEKc8E95CobkUpAj12nvHqyuhASAMtEsxfDSyHKkh3S00KY0zYi2B";
        private string url = "https://localhost:5001/checkout";
        
        public OrderService(HttpClient client)
        {
            this.client = client;
            StripeConfiguration.ApiKey = secretKey;
        }

        public async Task CreateOrderAsync(GrpcFileGeneration.Models.Order.Order order)
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
            var postAsync =  await client.PostAsync(url, stringContent);
            
            //Step 5 - If success, return, if not throw exception
            CheckException(postAsync);
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