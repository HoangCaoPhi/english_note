using FluentValidation;

namespace EnglishNote.Presentation.Private.WordEndpoints.CreateWord;
internal class WordMeaningRequestValidator : AbstractValidator<WordMeaningRequest>
{
    public WordMeaningRequestValidator()
    {
        RuleFor(x => x.Definitions)
            .NotEmpty()
            .NotNull()
            .Must(x => x.Count > 0)
            .ForEach(definition => definition.SetValidator(new WorkDefinitionRequestValidator()));
    }
}
