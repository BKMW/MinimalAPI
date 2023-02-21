using Application;
using Application.Services;
using JwtAuthManager;
using MinimalAPI.EndPoints;
using MinimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddServices();

builder.Services.AddCustomJwtAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UseAuthentication();
app.UseAuthorization();


app.UseWeatherEndPoints();

app.Run();  


