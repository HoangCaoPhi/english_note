using EnglishNote.Application.Abtractions.Storage;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishNote.Infrastructure.Storage;

public static class ServiceExtensions
{
    public static IServiceCollection AddStorageLayer(this IServiceCollection services,
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
