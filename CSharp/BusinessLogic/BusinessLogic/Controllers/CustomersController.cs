using System;
using System.Threading.Tasks;
using BusinessLogic.Model.Customers;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private ICustomerModel model;

        public CustomersController(ICustomerModel model)
        {
            this.model = model;
        }
        
        [HttpPost(Name = "CreateCustomerRoute")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            // try
            // {
                var customerAsync = await model.CreateCustomerAsync(customer);
                return Ok(customerAsync);
            // }
            // catch (Exception e)
            // {
            //     return StatusCode(403, e.Message);
            // }
        }
    }
}