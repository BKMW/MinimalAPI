﻿using Application.Services;
using Microsoft.AspNetCore.Authorization;

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


            app.MapGet("/List",
               // [Authorize]
                (IWeatherForecastServices _weatherForecastServices) =>
            {
                return _weatherForecastServices.GetWeather();
            })
            .RequireAuthorization()
            .WithTags("Users");
        }


    }
}
