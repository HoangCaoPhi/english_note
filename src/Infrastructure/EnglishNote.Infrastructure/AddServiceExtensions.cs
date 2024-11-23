using EnglishNote.Application.Abtractions.Authentication;
using EnglishNote.Infrastructure.Authentication;
using EnglishNote.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishNote.Infrastructure;

public static class AddServiceExtensions
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<IIdentityService, IdentityService>();

        services.AddPersistenceLayer(configuration);
        
        return services;
    }
}
