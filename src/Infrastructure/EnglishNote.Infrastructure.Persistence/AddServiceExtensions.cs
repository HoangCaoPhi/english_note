using BuildingBlocks.Application;
using EnglishNote.Domain.Tags;
using EnglishNote.Infrastructure.Persistence.Contexts;
using EnglishNote.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishNote.Infrastructure.Persistence;
public static class AddServiceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositoryService()
                .ConfigureDbContext(configuration);

        return services;
    }

    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITagRepository, TagRepository>();
        return services;
    }

    private static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationWriteDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddDbContext<ApplicationReadDbContext>(options =>
        {
            options
                .UseSqlServer(configuration.GetConnectionString("SqlServer"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }
}
