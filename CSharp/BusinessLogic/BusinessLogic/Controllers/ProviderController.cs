using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Model;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {
        private IProviderModel model;
        private string baseUri = "https://localhost:5001/Provider";

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
                AddLinks(provider);
            }

            list.Links.Add(new Link()
            {
                Method = "GET",
                Href = baseUri,
                Rel = "self"
            });
            return Ok(list);
        }
        
        private void AddLinks(Provider provider)
        {
            provider.Links.Add(new Link()
            {
                Rel = $"{baseUri}/{provider.Id}",
                Href = "self",
                Method = "GET"
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Provider>> GetProviderById([FromRoute] int id)
        {
            var providerById = await model.GetProviderById(id);
            AddLinks(providerById);
            return Ok(providerById);
        }

        [HttpPost]
        public async Task CreateProvider([FromBody] Provider provider)
        {
            await model.CreateProvider(provider);
        }
    }
}