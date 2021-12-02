using System;
using System.Threading.Tasks;
using BusinessLogic.Model.Customers;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult<CustomerList>> GetAllCustomersAsync()
        {
            CustomerList allCustomersAsync = new()
            {
                Customers = await model.GetAllCustomersAsync()
            };

            return Ok(allCustomersAsync);
        }

        [HttpDelete]
        [Route("{customerId:int}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            await model.DeleteCustomerAsync(customerId);
            return Ok();
        }
        
         
        [HttpGet("{id:int}", Name = "GetCustomerByIdRoute")]
        public async Task<ActionResult<User>> GetCustomerById([FromRoute] int id)
        {
            var providerById = await model.GetCustomerByIdAsync(id);
            return Ok(providerById);
        }
        
        //[Authorize(Roles = "Customer")]
        [HttpPatch("{id:int}",Name = "EditCustomerRoute")]
        public async Task<ActionResult<Customer>> EditCustomer([FromBody] Customer customer)
        {
            try
            {
                Customer editedCustomer = await model.EditCustomerAsync(customer);
                return Ok(editedCustomer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
           
        }
    }
}