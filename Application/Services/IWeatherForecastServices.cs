using Domain.Models;

namespace Application.Services
{
    public interface IWeatherForecastServices
    {

        WeatherForecast[] GetWeather();

    }
}
