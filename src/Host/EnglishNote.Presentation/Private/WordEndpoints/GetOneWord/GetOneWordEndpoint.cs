using EnglishNote.Application.UseCases.Words.GetOneWord;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.WordEndpoints.GetOneWord;
internal class GetOneWordEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Word;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("{wordId}", async (ISender sender,
            Guid wordId) =>
        {
            return await sender.Send(new GetOneWordQuery(wordId));
        });
    }
}
