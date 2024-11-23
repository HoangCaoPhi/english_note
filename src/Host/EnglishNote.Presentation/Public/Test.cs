using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace EnglishNote.Presentation.Public;
internal sealed class Test : IPublicEndpoint
{
    public string EndpointName => EndpointSchema.Test;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("", () =>
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyPath = assembly.Location;

            var buildTime = File.GetLastWriteTime(assemblyPath);
            var machineName = Environment.MachineName;

            return new
            {
                MachineName = machineName,
                BuildTime = buildTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
        });
    }
}
