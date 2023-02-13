using Application;
using Application.Services;
using MinimalAPI.EndPoints;
using MinimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();


app.UseWeatherEndPoints();

app.Run();  


