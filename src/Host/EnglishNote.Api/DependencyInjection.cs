using EnglishNote.Presentation.Abstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app) {
        IEnumerable<IEndpoint> endpoints = app
            .Services
            .GetServices<IEndpoint>();

        foreach (var endpoint in endpoints) {
            var routeGroup = app.MapGroup(endpoint.EndpointName);
            endpoint.MapEndpoint(routeGroup);
        }

        return app;
    }
}
