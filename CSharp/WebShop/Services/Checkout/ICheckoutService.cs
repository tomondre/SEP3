using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using WebShop.Models;

namespace WebShop.Services.Checkout
{
    public interface ICheckoutService
    {
        Task CheckoutAsync(Order order);
    }
}