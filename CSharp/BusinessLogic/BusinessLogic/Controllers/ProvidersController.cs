using System;
using System.Threading.Tasks;
using BusinessLogic.Model.Providers;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    //TODO set authorization depending on the role for each method [Authorize(Roles = "Administrator")]
    //[Authorize]
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

        //[Authorize(Roles = "Administrator")]
        [HttpGet(Name = "GetProvidersRoute")]
        public async Task<ActionResult<ProviderList>> GetProviders([FromQuery] bool? approved, [FromQuery] string name, [FromQuery] int page)
        {
            var list = new Page<ProviderList>();

            try
            {
                if (approved is true)
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        list = await model.GetAllProvidersAsync(page);
                    }
                    else
                    {
                        list = await model.GetAllProvidersByNameAsync(name, page);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        list = await model.GetAllNotApprovedProvidersAsync(page);
                    }
                    else
                    {
                        list = await model.GetAllProvidersByNameAsync(name,page);
                    }
                }
            
                foreach (var provider in list.Content.Providers)
                {
                    await linksService.AddLinksAsync(provider);
                }
                await linksService.AddLinksAsync(list.Content);
                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        
        [HttpGet("{id:int}", Name = "GetProviderByIdRoute")]
        public async Task<ActionResult<User>> GetProviderById([FromRoute] int id)
        {
            try
            {
                var providerById = await model.GetProviderByIdAsync(id);
                await linksService.AddLinksAsync(providerById);
                return Ok(providerById);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
           
        }

        //[Authorize(Roles = "Provider")]
        [HttpPatch("{id:int}",Name = "EditProviderRoute")]
        public async Task<ActionResult<Provider>> EditProvider([FromBody] Provider provider)
        {
            try
            {
                Provider editedProvider = await model.EditProviderAsync(provider);
                return Ok(editedProvider);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
           
        }

        [AllowAnonymous]
        [HttpPost(Name = "CreateProviderRoute")]
        public async Task<ActionResult<User>> CreateProvider([FromBody] Provider provider)
        {
            try
            {
                var user = await model.CreateProviderAsync(provider);
                return Ok(user);

            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
            
        }
        
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}", Name = "DeleteProviderRoute")]
        public async Task<ActionResult> DeleteProviderAsync([FromRoute] int id)
        {
            await model.DeleteProviderAsync(id);
            return Ok();
        }
    }
}