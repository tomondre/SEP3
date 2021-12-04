using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Orders;
using Networking.Order;
using Networking.Request;
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

        public async Task<Page<OrderList>> GetAllCustomerOrdersAsync(int id, int page)
        {
            var requestMessage = new RequestMessage
            {
                Id = id,
                PageInfo = new PageRequestMessage()
                {
                    PageNumber = page,
                    PageSize = 5
                }
            };
            var response = await client.getAllCustomerOrdersAsync(requestMessage);
            var orderMessage = response.Orders;
            var orders = new OrderList
            {
                Orders = orderMessage.Select(a => new Order(a)).ToList()
            };
            
            var ordersPage = new Page<OrderList>(response.PageInfo)
            {
                Content = orders
            };
            return ordersPage;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var orderByIdAsync = await client.getOrderByIdAsync(new RequestMessage() {Id = id});
            return new Order(orderByIdAsync);
        }
    }
}