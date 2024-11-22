using EnglishNote.Application.Behaviors;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EnglishNote.Application;

public static class AddServiceExtensions
{
    private readonly static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services
            .ConfigureMediatR()
            .ConfigureMapster()
            .ConfigureFluentValidation();

        return services;
    }

    public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly);

            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        return services;
    }

    public static IServiceCollection ConfigureMapster(this IServiceCollection services) {
        var globalConfig = TypeAdapterConfig.GlobalSettings;
        globalConfig.Scan(Assemblies);

        services.AddSingleton(globalConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly, includeInternalTypes: true);
        return services;
    }
}
