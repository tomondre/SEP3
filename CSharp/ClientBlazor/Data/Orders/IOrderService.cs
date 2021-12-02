using System.Threading.Tasks;
using GrpcFileGeneration.Models.Orders;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace ClientBlazor.Data.Orders
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<OrderList> GetCustomerOrdersAsync(int id);
    }
}