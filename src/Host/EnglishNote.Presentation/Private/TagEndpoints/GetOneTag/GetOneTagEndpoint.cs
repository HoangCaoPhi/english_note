using EnglishNote.Application.UseCases.Tags.GetOneTag;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.TagEndpoints.GetOneTag;
internal sealed class GetOneTagEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Tag;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/{tagId}", async (ISender sender, Guid tagId) =>
        {
            return await sender.Send(new GetOneTagQuery(tagId));
        })
        .Produces<GetOneTagViewModel>()
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);
    }
}
