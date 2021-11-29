using System.Threading.Tasks;
using BusinessLogic.Model.Experiences;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Authorize]
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
        [Route("/Providers/{id:int}/Experiences")]
        [Authorize(Roles = "Administrator, Provider")]
        public async Task<ActionResult<ExperienceList>> GetExperiences([FromRoute] int id)
        {
            ExperienceList experiences = await model.GetAllProviderExperiencesAsync(id);
            return Ok(experiences);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Experience>> GetExperienceById([FromRoute] int id)
        {
            Experience experience = await model.GetExperienceByIdAsync(id);
            return Ok(experience);
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ExperienceList>> GetAllExperiencesAsync()
        {
            ExperienceList experiences = await model.GetAllWebShopExperiencesAsync();
            return Ok(experiences);
        }

        [HttpPost]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult<Experience>> AddExperienceAsync([FromBody]Experience experience)
        {
            var addExperienceAsync = await model.AddExperienceAsync(experience);
            return Ok(addExperienceAsync);
        }

        [HttpDelete]
        [Route("{experienceId:int}")]
        [AllowAnonymous]
        // [Authorize(Roles = "Administrator, Provider")]
        public async Task<ActionResult> DeleteExperienceAsync([FromRoute] int experienceId)
        {
            await model.DeleteExperienceAsync(experienceId);
            return Ok();
        }
    }
}