using EnglishNote.Api;
using EnglishNote.Api.Infrastructure.Extensions;
using EnglishNote.Api.Infrastructure.OpenApi.Transformers;
using EnglishNote.Application;
using EnglishNote.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
 

builder.Services.AddOpenApi("internal", options =>
{
    options.AddDocumentTransformer<BasicOperationTransformer>();
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.AddOpenApi("public", options =>
{
    options.AddDocumentTransformer<BasicOperationTransformer>();
});
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpoints(typeof(EnglishNote.Presentation.IAssemblyMarker).Assembly);

builder
    .Services
    .AddApplicationServices()
    .AddInfrastructureLayer(builder.Configuration)
    .AddApplicationLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "English Note API";
        options.AddServer(new ScalarServer("https://localhost:7176"));
    });
 
    app.MigrationDatabase();
}

 
app.MapEndpoints();
app.UseExceptionHandler();

app.Run();
 