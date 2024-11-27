using EnglishNote.Application.Abtractions;
using EnglishNote.Application.Abtractions.Authentication;
using EnglishNote.Infrastructure.Authentication;
using EnglishNote.Infrastructure.Persistence;
using EnglishNote.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishNote.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<IIdentityService, IdentityService>();

        services
            .AddServiesLayer()
            .AddPersistenceLayer(configuration);
        
        return services;
    }

    public static IServiceCollection AddServiesLayer(this IServiceCollection services)
    {
        services.AddScoped<IGuidGenerator, GuidGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    } 
}
