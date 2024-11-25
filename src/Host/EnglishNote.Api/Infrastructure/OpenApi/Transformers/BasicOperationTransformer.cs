using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace EnglishNote.Api.Infrastructure.OpenApi.Transformers;

internal sealed class BasicOperationTransformer : IOpenApiDocumentTransformer
{
    public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Info = new OpenApiInfo()
        {
            Title = "English Note API",
            Description = "The English Note API provides endpoints for managing and retrieving notes related to the English language. Users can create, update, and delete notes, as well as retrieve lists of their saved notes for learning and reference.",
            Version = "1.0.0",
        };
    }
}
