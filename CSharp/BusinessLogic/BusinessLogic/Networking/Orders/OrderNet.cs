using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models.Orders;
using Networking.Order;
using Networking.User;

namespace BusinessLogic.Networking.Orders
{
    public class OrderNet : IOrderNet
    {
        private OrderService.OrderServiceClient client;
        
        public OrderNet(OrderService.OrderServiceClient client)
        {
            this.client = client;
        }
        
        public async Task<Order> CreateOrderAsync(Order order)
        {
            var result = await client.createOrderAsync(order.ToMessage());
            return new Order(result);
        }

        public async Task<IList<Order>> GetAllCustomerOrdersAsync(int id)
        {
            var messages = await client.getAllCustomerOrdersAsync(new UserMessage{Id = id});
            IList<Order> result = new List<Order>();
            foreach (var order in messages.Orders)
            {
                result.Add(new Order(order));
            }
            return result;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var orderByIdAsync = await client.getOrderByIdAsync(new OrderMessage {Id = id});
            return new Order(orderByIdAsync);
        }
    }
}