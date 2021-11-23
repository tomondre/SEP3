using System.Threading.Tasks;

namespace BusinessLogic.Networking.Order
{
    public interface IOrderNet
    {
        Task<GrpcFileGeneration.Models.Order.Order> CreateOrderAsync(GrpcFileGeneration.Models.Order.Order order);
    }
}