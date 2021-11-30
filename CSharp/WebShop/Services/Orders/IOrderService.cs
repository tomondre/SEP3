using System.Threading.Tasks;
using GrpcFileGeneration.Models.Orders;
using OrderStripe = Stripe.Order;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace WebShop.Services.Orders
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
        Task<OrderList> GetCustomerOrdersAsync(int id);
    }
}