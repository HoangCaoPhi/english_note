using FluentValidation.Results;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Results;
using SharpGrip.FluentValidation.AutoValidation.Shared.Extensions;
using System.Net;

namespace EnglishNote.Api.Filters;


public class ValidationResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IResult CreateResult(EndpointFilterInvocationContext context, ValidationResult validationResult)
    {
        var validationProblemErrors = validationResult.ToValidationProblemErrors();

        return Results.ValidationProblem(validationProblemErrors, "Some details text.", "Some instance text.", (int)HttpStatusCode.BadRequest, "Some title.");
    }
}