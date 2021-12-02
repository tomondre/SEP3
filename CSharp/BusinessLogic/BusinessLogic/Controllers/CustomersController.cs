using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Model.Customers;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private ICustomerModel model;

        public CustomersController(ICustomerModel model)
        {
            this.model = model;
        }
        
        [AllowAnonymous]
        [HttpPost(Name = "CreateCustomerRoute")]
        public async Task<ActionResult<User>> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var customerAsync = await model.CreateCustomerAsync(customer);
                return Ok(customerAsync);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<CustomerList>> GetAllCustomersAsync([FromQuery(Name = "name")] string name)
        {
            CustomerList allCustomersAsync = new();
            if (string.IsNullOrEmpty(name))
            {
                allCustomersAsync.Customers = await model.GetAllCustomersAsync();

            }
            else
            {
                allCustomersAsync.Customers = await model.FindCustomerByNameAsync(name);
            }
            return Ok(allCustomersAsync);
        }

        [HttpDelete]
        [Route("{customerId:int}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            await model.DeleteCustomerAsync(customerId);
            return Ok();
        }
    }
}