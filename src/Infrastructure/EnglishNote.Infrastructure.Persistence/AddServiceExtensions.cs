using EnglishNote.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishNote.Infrastructure.Persistence;
public static class AddServiceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
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
