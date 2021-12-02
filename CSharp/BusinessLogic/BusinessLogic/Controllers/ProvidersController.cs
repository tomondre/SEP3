﻿using System;
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
        public async Task<ActionResult<ProviderList>> GetProviders([FromQuery] bool? approved, [FromQuery] string name)
        {
            ProviderList list = new ProviderList();

            if (approved is true)
            {
                if (string.IsNullOrEmpty(name))
                {
                    list.Providers = await model.GetAllProviders();
                }
                else
                {
                    list.Providers = await model.GetAllProvidersByNameAsync(name);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(name))
                {
                    list.Providers = await model.GetAllNotApprovedProviders();
                }
                else
                {
                    list.Providers = await model.GetAllProvidersByNameAsync(name);
                }
            }
            
            foreach (var provider in list.Providers)
            {
                await linksService.AddLinksAsync(provider);
            }
            await linksService.AddLinksAsync(list);
            return Ok(list);
        }

        
        [HttpGet("{id:int}", Name = "GetProviderByIdRoute")]
        public async Task<ActionResult<User>> GetProviderById([FromRoute] int id)
        {
            var providerById = await model.GetProviderById(id);
            await linksService.AddLinksAsync(providerById);
            return Ok(providerById);
        }

        //TODO is it only the provider that can edit himself or also the administrator
        //[Authorize(Roles = "Provider")]
        [HttpPatch("{id:int}",Name = "EditProviderRoute")]
        public async Task<ActionResult> EditProvider([FromBody] Provider provider, [FromRoute] int id)
        {
            provider.Id = id;   
            await model.EditProvider(provider);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(Name = "CreateProviderRoute")]
        public async Task<ActionResult<User>> CreateProvider([FromBody] Provider provider)
        {
            try
            {
                var user = await model.CreateProvider(provider);
                return Ok(user);

            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
            
        }
        
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}", Name = "DeleteProviderRoute")]
        public async Task<ActionResult> DeleteProvider([FromRoute] int id)
        {
            await model.DeleteProvider(id);
            return Ok();
        }
    }
}