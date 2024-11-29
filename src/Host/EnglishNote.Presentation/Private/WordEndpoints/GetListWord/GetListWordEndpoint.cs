using EnglishNote.Application.UseCases.Words.GetListWord;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.WordEndpoints.GetListWord;
internal sealed class GetListWordEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Word;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("", async ([AsParameters] GetListWordRequest request,
                              ISender sender, 
                              IMapper mapper) =>
        {
            var query = mapper.Map<GetListWordQuery>(request);
            return await sender.Send(query);
        });
    }
}
