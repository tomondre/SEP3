using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
        }

        [HttpGet]
        public async Task<string> Get()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:9090");
            var client = new ProviderService.ProviderServiceClient(channel);
            var reply = await client.getAllProvidersAsync(new Request());
            return reply.Value.ToString();
        }
    }
}