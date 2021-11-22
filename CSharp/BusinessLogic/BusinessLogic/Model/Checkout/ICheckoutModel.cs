using System.Threading.Tasks;
using WebShop.Models;

namespace BusinessLogic.Model
{
    public interface ICheckoutModel
    {
        Task<Order> CheckoutAsync(Order order);
    }
}