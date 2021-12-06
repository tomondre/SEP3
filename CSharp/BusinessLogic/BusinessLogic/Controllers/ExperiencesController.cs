using System;
using System.Threading.Tasks;
using BusinessLogic.Model.Experiences;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExperiencesController : ControllerBase
    {
        private IExperienceModel model;
        private ILinksService linksService;

        public ExperiencesController(ILinksService linksService, IExperienceModel model)
        {
            this.linksService = linksService;
            this.model = model;
        }

        [HttpGet("/Providers/{id:int}/Experiences", Name = "GetProviderExperienceRoute")]
        // [Authorize(Roles = "Administrator, Provider")]
        public async Task<ActionResult<ExperienceList>> GetProviderExperiences([FromRoute] int id, [FromQuery] string name)
        {
            try
            {
                ExperienceList experiences = new ExperienceList();
                if (string.IsNullOrEmpty(name))
                {
                    experiences.Experiences = await model.GetAllProviderExperiencesAsync(id);
                }
                else
                {
                    experiences.Experiences = await model.GetAllProviderExperiencesByNameAsync(id, name);
                }

                await AddLinks(experiences);                
                return Ok(experiences);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        [HttpGet("/Categories/{id:int}/Experiences", Name = "GetExperienceByCategoryRoute")]
        // [Authorize(Roles = "Administrator, Provider")]
        public async Task<ActionResult<ExperienceList>> GetExperiencesByCategoryAsync([FromRoute] int id)
        {
            try
            {
                ExperienceList experiences = new ExperienceList
                {
                    Experiences = await model.GetExperiencesByCategoryAsync(id)
                };
                await AddLinks(experiences);
                return Ok(experiences);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }
        
        [HttpGet("{id:int}", Name = "GetExperienceByIdRoute")]
        public async Task<ActionResult<Experience>> GetExperienceByIdAsync([FromRoute] int id)
        {
            try
            {
                Experience experience = await model.GetExperienceByIdAsync(id);
                await AddLink(experience);
                return Ok(experience);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }


        [HttpGet(Name = "GetAllExperiencesRoute")]
        public async Task<ActionResult<ExperienceList>> GetAllExperiencesAsync([FromQuery] bool? top, [FromQuery(Name = "name")] string name)
        {
            try
            {
                ExperienceList experiences = new ExperienceList();
                if (top == null)
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        experiences.Experiences = await model.GetAllWebShopExperiencesAsync();
                    }
                    else
                    {
                        experiences.Experiences = await model.GetExperiencesByNameAsync(name);
                    }
                }
                else
                {
                    experiences.Experiences = await model.GetTopExperiences();
                }

                await AddLinks(experiences);
                return Ok(experiences);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        [HttpPost(Name = "CreateExperienceRoute")]
        // [Authorize(Roles = "Provider")]
        public async Task<ActionResult<Experience>> AddExperienceAsync([FromBody] Experience experience)
        {
            try
            {
                var addExperienceAsync = await model.AddExperienceAsync(experience);
                await AddLink(addExperienceAsync);
                return Ok(addExperienceAsync);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteExperienceRoute")]
        [AllowAnonymous]
        // [Authorize(Roles = "Administrator, Provider")]
        public async Task<ActionResult> DeleteExperienceAsync([FromRoute] int id)
        {
            try
            {
                await model.DeleteExperienceAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        private async Task AddLink(Experience experience)
        {
            try
            {
                await linksService.AddLinksAsync(experience);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private async Task AddLinks(ExperienceList list)
        {
            try
            {
                foreach (var e in list.Experiences)
                {
                    await linksService.AddLinksAsync(e);
                }

                await linksService.AddLinksAsync(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}