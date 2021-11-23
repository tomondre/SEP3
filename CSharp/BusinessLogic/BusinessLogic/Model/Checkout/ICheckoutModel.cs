using System.Threading.Tasks;
using GrpcFileGeneration.Models.Order;

namespace BusinessLogic.Model.Checkout
{
    public interface ICheckoutModel
    {
        Task<Order> CheckoutAsync(Order order);
    }
}