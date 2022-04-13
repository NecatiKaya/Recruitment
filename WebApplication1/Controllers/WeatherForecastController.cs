using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recruitment.Client.CommandQueryApi;
using Recruitment.Client.CommandQueryApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<HashedResult> Get()
        {
            ICommandQueryApiClient client = new CommandQueryApiClient("http://localhost:5000/hash/");
            var result = await client.GenerateHashAsync(new Recruitment.Client.CommandQueryApi.Requests.CalculateHashRequest() { Login = "1", Password = "2" });
            return result;
        }
    }
}
