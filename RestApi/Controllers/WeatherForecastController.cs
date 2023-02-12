using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastServices _weatherForecastServices;



        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastServices weatherForecastServices
            )
        {
            _logger = logger;
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastServices.GetWeather();

        }
    }
}