using System;
using System.Threading.Tasks;
using BusinessLogic.Model.Orders;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrderModel model;
        private ILinksService linksService;

        public OrdersController(ILinksService linksService, IOrderModel orderModel)
        {
            this.linksService = linksService;
            model = orderModel;
        }
        
        [HttpPost(Name = "CreateOrderRoute")]
        public async Task<ActionResult<Order>> CreateOrderAsync([FromBody] Order order)
        {
            try
            {
                var checkout = await model.CreateOrderAsync(order);
                await AddLink(checkout);
                return Ok(checkout);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(403, e.Message);
            }
        }

        [HttpGet("/customers/{customerId:int}/orders", Name = "AllCustomerOrdersRoute")]
        public async Task<ActionResult<Page<OrderList>>> GetAllCustomerOrdersAsync([FromRoute] int customerId, [FromQuery] int page)
        {
            try
            {
                var allCustomerOrdersAsync = await model.GetAllCustomerOrdersAsync(customerId, page);
                await AddLinks(allCustomerOrdersAsync.Content);
                return Ok(allCustomerOrdersAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403);
            }
        }
        
        [HttpGet("{id:int}", Name = "GetOrderByIdRoute")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync([FromRoute] int id)
        {
            try
            {
                var orderById = await model.GetOrderByIdAsync(id);
                await AddLink(orderById);
                return Ok(orderById);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403);
            }
        }

        private async Task AddLink(Order order)
        {
            try
            {
                await linksService.AddLinksAsync(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task AddLinks(OrderList orderList)
        {
            try
            {
                foreach (var order in orderList.Orders)
                {
                    await linksService.AddLinksAsync(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}