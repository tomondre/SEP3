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
        [HttpPost]
        public async Task<ActionResult<User>> AuthenticateUser([FromBody] User userCred)
        {
            var authenticate = await model.AuthenticateUserAsync(userCred);
            if (authenticate == null)
            {
                return Unauthorized();
            }
            
            return Ok(authenticate);
        }
    }
}