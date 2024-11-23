using EnglishNote.Application.UseCases.Tags.CreateTag;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.TagEndpoints.CreateTag;
internal class CreateEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Tag;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (CreateTagRequest request, ISender sender) =>
        {
            await sender.Send(new CreateTagCommand(request.Name, request.Description));
        })
        .Produces<Guid>()
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);
    }
}
