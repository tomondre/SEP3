using System;
using System.Threading.Tasks;
using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private ICheckoutModel model;
        
        public CheckoutController(ICheckoutModel model)
        {
            this.model = model;
        }
        
        [HttpPost(Name = "CheckoutRoute")]
        public async Task<ActionResult<Order>> CreateCustomer([FromBody] Order order)
        {
            try
            {
                var checkout = await model.CheckoutAsync(order);
                return Ok(checkout);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}