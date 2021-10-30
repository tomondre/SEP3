using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : ControllerBase
    {
        private ILinksService linksService;

        public LinkController(ILinksService linksService)
        {
            this.linksService = linksService;
        }
        
        [HttpGet(Name = "GetLinks")]
        public async Task<ActionResult<ProviderList>> GetLinks()
        {
            HandShake handShake = new HandShake();
            await linksService.AddLinksAsync(handShake);
            return Ok(handShake);
        }
    }
}