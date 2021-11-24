using System.Threading.Tasks;
using BusinessLogic.Networking.User;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserNet model;
        
        public UserController(IUserNet model)
        {
            this.model = model;
        }
        
        [HttpPost]
        public async Task AddUser()
        {
            model.AddProductCategoryAsync();
        }
    }
}