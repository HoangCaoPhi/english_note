using EnglishNote.Application.Abtractions;
using EnglishNote.Application.Abtractions.Authentication;
using EnglishNote.Application.Abtractions.Storage;
using EnglishNote.Infrastructure.Authentication;
using EnglishNote.Infrastructure.Persistence;
using EnglishNote.Infrastructure.Services;
using EnglishNote.Infrastructure.Storage;
using Microsoft.Extensions.Azure;
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

        services.ConfigureStorage(configuration);
        
        return services;
    }

    public static IServiceCollection AddServiesLayer(this IServiceCollection services)
    {
        services.AddScoped<IGuidGenerator, GuidGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection ConfigureStorage(this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddScoped<IStorageService, AzureBlobStorageService>();

        var azureStorageOptions = configuration
                                    .GetSection(AzureStorageOptions.SectionName)
                                    .Get<AzureStorageOptions>();

        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder
               .AddBlobServiceClient(azureStorageOptions.ConnectionString)
               .ConfigureOptions(options =>
               {
                   options.Retry.Mode = Azure.Core.RetryMode.Exponential;
                   options.Retry.MaxRetries = 5;
                   options.Retry.MaxDelay = TimeSpan.FromSeconds(120);
               });
        });

        return services;
    }
}
