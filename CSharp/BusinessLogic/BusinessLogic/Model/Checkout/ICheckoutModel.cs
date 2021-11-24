using System.Threading.Tasks;

namespace BusinessLogic.Model.Checkout
{
    public interface ICheckoutModel
    {
        Task<GrpcFileGeneration.Models.Order.Order> CheckoutAsync(GrpcFileGeneration.Models.Order.Order order);
    }
}