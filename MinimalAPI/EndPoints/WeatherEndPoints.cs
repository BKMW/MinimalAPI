using Application.Services;

namespace MinimalAPI.EndPoints
{
    public static class WeatherEndPoints
    {
        public static void UseWeatherEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/weatherforecast", (IWeatherForecastServices _weatherForecastServices) =>
            {
                return _weatherForecastServices.GetWeather();
            })
              .WithName("GetWeatherForecast")
              .WithOpenApi();


            app.MapGet("/List", (IWeatherForecastServices _weatherForecastServices) =>
            {
                return _weatherForecastServices.GetWeather();
            });
        }


    }
}
