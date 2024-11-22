using EnglishNote.Application.UseCases.Tags.CreateTag;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.TagEndpoints.Create;
internal class CreateEndpoint : IEndpoint
{
    public string EndpointName => EndpointSchema.Tag;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (CreateTagRequest request, ISender sender) =>
        {
            await sender.Send(new CreateTagCommand(request.Name, request.Description));
        })
        .WithTags(EndpointSchema.Tag);
    }
}
