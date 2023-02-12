using MinimalAPI.Models;

namespace MinimalAPI.Services
{
    public interface IWeatherForecastServices
    {

         WeatherForecast[] GetWeather();
        
    }
}
