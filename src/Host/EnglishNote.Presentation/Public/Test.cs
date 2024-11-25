using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
        }) 
       .WithSummary("This is a summary.")
       .WithDescription("This is a description.")
       .WithName("This is a Name")
       .WithDisplayName("This is a DisplayName");
    }
}
