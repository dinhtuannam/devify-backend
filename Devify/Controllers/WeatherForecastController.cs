using Devify.Application.Interfaces;
using Devify.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICacheRepository _cacheService;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICacheRepository cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpGet("getall")]
        [Cache(1000)]
        public async Task<IActionResult> Get(int pageIndex = 1 , int pageSize = 10)
        {
            var result = new List<WeatherForecast>()
            {
                new WeatherForecast(){ Name = "abc" },
                new WeatherForecast(){ Name = "abc" },
                new WeatherForecast(){ Name = "abc" },
                new WeatherForecast(){ Name = "abc" },
            };
            return Ok(result);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await _cacheService.RemoveCacheResponseAsync("/WeatherForecast/getall");
            return Ok();
        }
    }
}