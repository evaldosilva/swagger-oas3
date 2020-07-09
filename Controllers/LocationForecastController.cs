using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using swagger_oas3.Domains.Forecast;
using System;

namespace swagger_oas3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public LocationForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public LocationForecast Get()
        {
            var rng = new Random();
            LocationForecast location = new LocationForecast(rng.Next(-85, 85), rng.Next(-180, 180));
            return location;
        }
    }
}