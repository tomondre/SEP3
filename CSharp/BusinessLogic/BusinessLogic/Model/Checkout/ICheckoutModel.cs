using System.Threading.Tasks;
using OrderStripe = Stripe.Order;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace BusinessLogic.Model.Checkout
{
    public interface ICheckoutModel
    {
        Task<Order> CheckoutAsync(Order order);
    }
}