using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models.Orders;

namespace BusinessLogic.Model.Orders
{
    public interface IOrderModel
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IList<Order>> GetAllCustomerOrdersAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
        Task GenerateVoucher();
    }
}