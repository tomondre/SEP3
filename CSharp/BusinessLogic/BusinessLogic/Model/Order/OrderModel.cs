using System.Threading.Tasks;
using BusinessLogic.Networking.Order;

namespace BusinessLogic.Model.Order
{
    public class OrderModel : IOrderModel
    {
        private IOrderNet networking;

        public OrderModel(IOrderNet networking)
        {
            this.networking = networking;
        }

        public async Task<GrpcFileGeneration.Models.Order.Order> CreateOrderAsync(GrpcFileGeneration.Models.Order.Order order)
        {
            return await networking.CreateOrderAsync(order);
        }
    }
}