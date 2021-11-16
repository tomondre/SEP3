using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Model.Experiences;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class ExperiencesController : ControllerBase
    {
        private IExperienceModel model;

        public ExperiencesController(IExperienceModel model)
        {
            this.model = model;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Experience>>> GetAllExperiencesAsync([FromQuery] Provider provider)
        {
            IList<Experience> experiences = new List<Experience>();
            if (provider != null)
            {
                experiences = await model.GetAllProviderExperiencesAsync(provider);
            }
            else
            {
                experiences = await model.GetAllWebShopExperiencesAsync();
            }

            return Ok(experiences);
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> AddExperienceAsync(Experience experience)
        {
            var addExperienceAsync = await model.AddExperienceAsync(experience);
            return Ok(addExperienceAsync);
        }
    }
}