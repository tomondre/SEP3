using System.Threading.Tasks;

namespace BusinessLogic.Model.Order
{
    public interface IOrderModel
    {
        Task<GrpcFileGeneration.Models.Order.Order> CreateOrderAsync(GrpcFileGeneration.Models.Order.Order order);
    }
}