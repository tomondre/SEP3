using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Orders;
using OrderStripe = Stripe.Order;

namespace BusinessLogic.Networking.Orders
{
    public interface IOrderNet
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Page<OrderList>> GetAllCustomerOrdersAsync(int id, int page);
        Task<Order> GetOrderByIdAsync(int id);
    }
}