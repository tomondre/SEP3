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
        [Route("{id:int}")]
        public async Task<ActionResult<ExperienceList>> GetExperiences(int? id)
        {
            ExperienceList experiences = new ExperienceList();
            experiences.Experiences = await model.GetAllProviderExperiencesAsync(id.Value);
            return Ok(experiences);
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ExperienceList>> GetAllExperiencesAsync()
        {
            ExperienceList experiences = new ExperienceList();
            experiences.Experiences = await model.GetAllWebShopExperiencesAsync();
            return Ok(experiences);
        }
        
        [HttpPost]
        public async Task<ActionResult<Experience>> AddExperienceAsync([FromBody] Experience experience)
        {
            var addExperienceAsync = await model.AddExperienceAsync(experience);
            return Ok(addExperienceAsync);
        }
    }
}