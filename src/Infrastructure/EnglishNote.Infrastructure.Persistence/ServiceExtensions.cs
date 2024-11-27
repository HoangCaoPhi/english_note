using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Domain.AggregatesModel.Words;
using EnglishNote.Infrastructure.Persistence.Contexts;
using EnglishNote.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishNote.Infrastructure.Persistence;
public static class ServiceExtensions
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositoryService()
                .ConfigureDbContext(configuration);

        return services;
    }

    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IWordRepository, WordRepository>();
        return services;
    }

    private static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationWriteDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IApplicationReadDbContext, ApplicationReadDbContext>();

        return services;
    }
}
