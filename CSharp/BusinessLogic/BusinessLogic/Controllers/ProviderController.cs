using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLogic.Model;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public async Task<IList<Provider>> Get()
        {
            return await model.GetAllProviders();
        }

        [HttpPost]
        public async Task CreateProvider([FromBody] Provider provider)
        {
            await model.CreateProvider(provider);
        }
    }
}