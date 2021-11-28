using System.Threading.Tasks;

namespace WebShop.Services.Order
{
    public interface IOrderService
    {
        Task CreateOrderAsync(GrpcFileGeneration.Models.Order.Order order);
        Task<GrpcFileGeneration.Models.Order.Order> GetOrderByIdAsync(int id);
    }
}