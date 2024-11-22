using Scalar.AspNetCore;
using EnglishNote.Infrastructure.Persistence;
using EnglishNote.Api;
using EnglishNote.Api.Extensions;
using EnglishNote.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpoints(typeof(EnglishNote.Presentation.IAssemblyMarker).Assembly);

builder
    .Services
    .AddPersistence(builder.Configuration)
    .AddApplicationLayer();

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

    app.MigrationDatabase();
}

 
app.MapEndpoints();

app.Run();
 