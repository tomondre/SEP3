using System;
using System.Threading.Tasks;
using BusinessLogic.Networking.Experiences;
using GrpcFileGeneration.Models.Order;
using Stripe;
using Order = GrpcFileGeneration.Models.Order.Order;

namespace BusinessLogic.Model.Checkout
{
    public class CheckoutModel : ICheckoutModel
    {
        private string secretKey = "sk_test_51JyZa3HP6RYbC1HUXv6ohA4Hz6PiePRCQUdo0R6xGXDqvnEKc8E95CobkUpAj12nvHqyuhASAMtEsxfDSyHKkh3S00KY0zYi2B";
        private IExperienceNet ExperienceNet;
        private IOrderNet OrderNet;
        public CheckoutModel(IExperienceNet experienceNet, IOrderNet orderNet)
        {
            ExperienceNet = experienceNet;
            OrderNet = orderNet; 
            StripeConfiguration.ApiKey = secretKey;
        }

        public async Task<Order> CheckoutAsync(Order order)
        {
            //Step 1 - Check if the experiences are in stock
            foreach (var item in order.ShoppingCart.ShoppingCartItems)
            {
                if (!await ExperienceNet.IsInStockAsync(item.Experience.Id, item.Quantity))
                {
                    throw new Exception("Not in stock!");
                }
            }

            //Step 2 - Create payment call to Stripe
             await CreatePayment(order);
            
            //Step 3 - Remove experiences stock from database
            foreach (var item in order.ShoppingCart.ShoppingCartItems)
            {
                 await ExperienceNet.RemoveStockAsync(item.Experience.Id, item.Quantity);
            }

            //Step 4 - Create Order + add generated id to the order object
            await OrderNet.CreateOrderAsync(order);
            
            //Step 5 - Generate vouchers
            
            
            //Step 6 - Return successful order
            return order;
        }

        
        private async Task CreatePayment(Order order)
        {
            var paymentIntentService = new PaymentIntentService();
            
            PaymentIntent paymentIntent = null;

            try
            {
                if (order.PaymentId != null)
                {
                    var options = new PaymentIntentCreateOptions
                    {
                        PaymentMethod = order.PaymentId,
                        Amount = Convert.ToInt64(order.ShoppingCart.OrderTotal),
                        Currency = "dkk",
                        ConfirmationMethod = "manual",
                        Confirm =  true
                    };

                    paymentIntent = await paymentIntentService.CreateAsync(options);
                }

                if (paymentIntent?.Status == "requires_action")
                {
                    throw new Exception("Action required");
                }
            }
            catch (StripeException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}