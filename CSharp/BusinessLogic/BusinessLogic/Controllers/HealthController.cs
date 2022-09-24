using System;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    public class HealthController : ControllerBase
    {
        [HttpGet("/health")]
        public async Task<ActionResult<String>> GetProviderExperiences()
        {
            return Ok("KO");
        }
    }
}