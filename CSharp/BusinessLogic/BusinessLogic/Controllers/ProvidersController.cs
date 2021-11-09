using System.Threading.Tasks;
using BusinessLogic.Model;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {
        private IProviderModel model;
        private ILinksService linksService;
        public ProviderController(ILinksService linksService, IProviderModel model)
        {
            this.linksService = linksService;
            this.model = model;
        }

        [HttpGet(Name = "GetProvidersRoute")]
        public async Task<ActionResult<ProviderList>> GetProviders([FromQuery] bool? approved)
        {
            ProviderList list = new ProviderList();
            
            if (approved is null or true)
            {
                list.Providers = await model.GetAllProviders();
            }
            else
            {
                list.Providers = await model.GetAllNotApprovedProviders();
            }
            
            foreach (var provider in list.Providers)
            {
                await linksService.AddLinksAsync(provider);
            }
            await linksService.AddLinksAsync(list);
            return Ok(list);
        }

        [HttpGet("{id:int}", Name = "GetProviderByIdRoute")]
        public async Task<ActionResult<Provider>> GetProviderById([FromRoute] int id)
        {
            var providerById = await model.GetProviderById(id);
            await linksService.AddLinksAsync(providerById);
            return Ok(providerById);
        }

        [HttpPatch("{id:int}",Name = "EditProviderRoute")]
        public async Task<ActionResult> EditProvider([FromBody] Provider provider, [FromRoute] int id)
        {
            provider.Id = id;   
            await model.EditProvider(provider);
            return Ok();
        }

        [HttpPost(Name = "CreateProviderRoute")]
        public async Task<ActionResult> CreateProvider([FromBody] Provider provider)
        {
            await model.CreateProvider(provider);
            return Ok();
        }
        
        [HttpDelete("{id:int}", Name = "DeleteProviderRoute")]
        public async Task<ActionResult> DeleteProvider([FromRoute] int id)
        {
            await model.DeleteProvider(id);
            return Ok();
        }
    }
}