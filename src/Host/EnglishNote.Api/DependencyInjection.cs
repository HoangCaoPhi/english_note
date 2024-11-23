using EnglishNote.Domain.AggregatesModel.Identity;
using EnglishNote.Infrastructure.Persistence.Contexts;
using EnglishNote.Presentation.Abstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Extentions;
using System.Reflection;

namespace EnglishNote.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    { 
        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                   type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(type.ImplementedInterfaces
                     .First(x => x != typeof(IEndpoint)), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddProblemDetails();

        services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationWriteDbContext>();

        services.AddAuthorization();
        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        RouteGroupBuilder privateRouteGroup = app
            .MapGroup("/")
            .RequireAuthorization();

        RouteGroupBuilder publicRouteGroup = app
            .MapGroup("/public");

        MapEndpointRoute<IPrivateEndpoint>(app, privateRouteGroup);
        MapEndpointRoute<IPublicEndpoint>(app, publicRouteGroup);

        app.MapGroup("Identity")
           .MapIdentityApi<ApplicationUser>()
           .WithTags("Identity");

        return app;
    }

    private static void MapEndpointRoute<TEndpoint>(
        WebApplication app,
        RouteGroupBuilder routeGroupBuilder)
        where TEndpoint : IEndpoint
    {
        IEnumerable<TEndpoint> endpoints = app
            .Services
            .GetServices<TEndpoint>();
 
        foreach (var endpoint in endpoints)
        {
            var routeGroup = routeGroupBuilder.MapGroup(endpoint.EndpointName)
                                              .WithTags(endpoint.EndpointName.CapitalizeFirstLetterOfSentence());
            endpoint.MapEndpoint(routeGroup);
        }
    }
}
