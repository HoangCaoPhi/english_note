using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.TagEndpoints.Create;
internal class CreateEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (CreateTagRequest request) =>
        {

        });
    }
}
