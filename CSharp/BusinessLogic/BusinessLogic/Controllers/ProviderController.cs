using System.Threading.Tasks;
using BusinessLogic.Model;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {
        private IProviderModel model;

        public ProviderController(IProviderModel model)
        {
            this.model = model;
        }

        [HttpGet]
        public async Task<ActionResult<ProviderList>> GetProviders()
        {
            ProviderList list = new ProviderList();
            list.Providers = await model.GetAllProviders();
            foreach (var provider in list.Providers)
            {
                CreateLinksForProvider(provider);
            }
            CreateLinksForProviderList(list);
            return Ok(list);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Provider>> GetProviderById([FromRoute] int id)
        {
            var providerById = await model.GetProviderById(id);
            CreateLinksForProvider(providerById);
            return Ok(providerById);
        }

        [HttpPatch]
        public async Task<ActionResult> EditProvider([FromBody] Provider provider)
        {
            await model.EditProvider(provider);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProvider([FromBody] Provider provider)
        {
            await model.CreateProvider(provider);
            return Ok();
        }

        private void CreateLinksForProviderList(ProviderList list)
        {
            var encodedUrl = UriHelper.GetEncodedUrl(Request);
            list.Links.Add(new Link()
            {
                Method = "GET",
                Href = encodedUrl,
                Rel = "self"
            });
        }

        private void CreateLinksForProvider(Provider provider)
        {
            var encodedUrl = UriHelper.GetEncodedUrl(Request);
            provider.Links.Add(new Link()
            {
                Href = $"{encodedUrl}/{provider.Id}",
                Rel = "self",
                Method = "GET"
            });
            provider.Links.Add(new Link()
            {
                Href = $"{encodedUrl}/{provider.Id}",
                Rel = "self",
                Method = "PATCH",
            });  
        }
    }
}