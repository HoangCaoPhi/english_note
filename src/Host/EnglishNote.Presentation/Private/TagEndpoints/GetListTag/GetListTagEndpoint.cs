using EnglishNote.Application.UseCases.Tags.GetListTag;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.TagEndpoints.GetListTag;
internal sealed class GetListTagEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Tag;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("", async ([AsParameters] GetListTagQuery request, 
            ISender sender,
            IMapper mapper) =>
        {
            var query = mapper.Map<GetListTagQuery>(request);
            return await sender.Send(query);
        });
    }
}
