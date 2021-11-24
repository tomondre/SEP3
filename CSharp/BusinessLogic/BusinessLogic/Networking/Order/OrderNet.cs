using System.Text.Json;
using System.Threading.Tasks;
using Networking.Order;

namespace BusinessLogic.Networking.Order
{
    public class OrderNet : IOrderNet
    {
        private OrderService.OrderServiceClient client;
        
        public OrderNet(OrderService.OrderServiceClient client)
        {
            this.client = client;
        }
        
        public async Task<GrpcFileGeneration.Models.Order.Order> CreateOrderAsync(GrpcFileGeneration.Models.Order.Order order)
        {
            var result = await client.createOrderAsync(order.ToMessage());
            return new GrpcFileGeneration.Models.Order.Order(result);
        }
    }
}