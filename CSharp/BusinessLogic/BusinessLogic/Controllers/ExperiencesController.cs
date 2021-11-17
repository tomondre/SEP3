using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLogic.Model.Experiences;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperiencesController : ControllerBase
    {
        private IExperienceModel model;

        public ExperiencesController(IExperienceModel model)
        {
            this.model = model;
        }
        
        [HttpGet]
        [Route("{provider:int}")]
        public async Task<ActionResult<IList<Experience>>> GetAllExperiencesAsync([FromRoute] int? provider)
        {
            IList<Experience> experiences = new List<Experience>();
            if (provider != null)
            {
                experiences = await model.GetAllProviderExperiencesAsync(provider.Value);
            }
            else
            {
                experiences = await model.GetAllWebShopExperiencesAsync();
            }

            return Ok(experiences);
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> AddExperienceAsync([FromBody]Experience experience)
        {
            var addExperienceAsync = await model.AddExperienceAsync(experience);
            return Ok(addExperienceAsync);
        }
    }
}