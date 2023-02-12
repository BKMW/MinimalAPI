using MinimalAPI.Models;

namespace MinimalAPI.Services
{
    public class WeatherForecastServices: IWeatherForecastServices
    {
        public  string[] summaries = new string[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast[] GetWeather()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
               new WeatherForecast
               (
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   summaries[Random.Shared.Next(summaries.Length)]
               ))
               .ToArray();
            return forecast;
        }
    }
}
