using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Orders;
using Order = GrpcFileGeneration.Models.Orders.Order;

namespace ClientBlazor.Data.Orders
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<Page<OrderList>> GetCustomerOrdersAsync(int id, int page);
        Task<ProvidersVoucherList> GetAllProviderVouchersAsync(int? id);
    }
}