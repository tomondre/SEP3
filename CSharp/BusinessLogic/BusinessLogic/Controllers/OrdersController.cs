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
        public async Task<ActionResult<Order>> CreateOrderAsync([FromBody] Order order)
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

        [HttpGet("/customers/{customerId:int}/orders", Name = "allCustomerOrdersRoute")]
        public async Task<ActionResult<OrderList>> GetAllCustomerOrdersAsync([FromRoute] int customerId)
        {
            var allCustomerOrdersAsync = await model.GetAllCustomerOrdersAsync(customerId);
            var orders = new OrderList();
            orders.Orders = allCustomerOrdersAsync;
            return Ok(orders);
        }
        
        [HttpGet("{id:int}", Name = "getOrderByIdRoute")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync([FromRoute] int id)
        {
            var orderById = await model.GetOrderByIdAsync(id);
            return Ok(orderById);
        }
    }
}