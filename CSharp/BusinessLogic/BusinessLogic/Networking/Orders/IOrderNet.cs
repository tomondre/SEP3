using System.Collections.Generic;
using System.Threading.Tasks;

using OrderStripe = Stripe.Order;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace BusinessLogic.Networking.Orders
{
    public interface IOrderNet
    {
        Task<Order> CreateOrderAsync(GrpcFileGeneration.Models.Orders.Order order);
        Task<IList<Order>> GetAllCustomerOrdersAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
    }
}