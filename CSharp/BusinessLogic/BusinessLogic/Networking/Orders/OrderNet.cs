using System;
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
            try
            {
                var result = await client.createOrderAsync(order.ToMessage());
                return new Order(result);
            }
            catch (Exception e)
            {
                throw new Exception("Order can't be created");
            }
        }

        public async Task<Page<OrderList>> GetAllCustomerOrdersAsync(int id, int page)
        {
            try
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
            catch (Exception)
            {
                throw new Exception("Customer orders can't be fetched");
            }
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            try
            {
                var orderByIdAsync = await client.getOrderByIdAsync(new OrderMessage {Id = id});
                return new Order(orderByIdAsync);
            }
            catch (Exception e)
            {
                throw new Exception("Order cant be fetched");
            }
        }
    }
}