using System;
using System.Threading.Tasks;
using BusinessLogic.Model.Orders;
using GrpcFileGeneration.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrderModel model;

        public OrdersController(IOrderModel orderModel)
        {
            model = orderModel;
        }
        
        [HttpPost(Name = "CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            try
            {
                var checkout = await model.CreateOrderAsync(order);
                return Ok(checkout);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(Name="allCustomerOrdersRoute")]
        public async Task<ActionResult<OrderList>> GetAllCustomerOrdersAsync([FromRoute] int id)
        {
            var allCustomerOrdersAsync = await model.GetAllCustomerOrdersAsync(id);
            var orders = new OrderList();
            orders.Orders = allCustomerOrdersAsync;
            return Ok(orders);
        }
        
        [HttpGet(Name = "getOrderByIdRoute")]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> GetOrderById([FromRoute] int id)
        {
            var orderById = await model.GetOrderByIdAsync(id);
            return Ok(orderById);
        }
    }
}