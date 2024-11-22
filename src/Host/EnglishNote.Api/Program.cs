using Scalar.AspNetCore;
using EnglishNote.Infrastructure.Persistence;
using EnglishNote.Api;
using EnglishNote.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpoints(typeof(EnglishNote.Presentation.IAssemblyMarker).Assembly);

builder
    .Services
    .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "English Note API";
        options.AddServer(new ScalarServer("https://localhost:7176"));
    });

    app.DbMigrate();
}

app.UseHttpsRedirection();
 
app.MapEndpoints();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
