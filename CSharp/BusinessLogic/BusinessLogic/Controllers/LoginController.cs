using System.Threading.Tasks;
using BusinessLogic.Model.Login;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginModel model;

        public LoginController(ILoginModel model)
        {
            this.model = model;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate/customer")]
        public async Task<ActionResult<Customer>> AuthenticateCustomer([FromBody] Login userCred)
        {
            var authenticate = await model.AuthenticateCustomerAsync(userCred.Email, userCred.Password);
            if (authenticate == null)
            {
                return Unauthorized();
            }
            
            return Ok(authenticate);
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate/provider")]
        public async Task<ActionResult<Customer>> AuthenticateProvider([FromBody] Login userCred)
        {
            var authenticate = await model.AuthenticateProviderAsync(userCred.Email, userCred.Password);
            if (authenticate == null)
            {
                return Unauthorized();
            }
            
            return Ok(authenticate);
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate/administrator")]
        public async Task<ActionResult<Customer>> AuthenticateAdministrator([FromBody] Login userCred)
        {
            var authenticate = await model.AuthenticateAdministratorAsync(userCred.Email, userCred.Password);
            if (authenticate == null)
            {
                return Unauthorized();
            }
            
            return Ok(authenticate);
        }
    }
}