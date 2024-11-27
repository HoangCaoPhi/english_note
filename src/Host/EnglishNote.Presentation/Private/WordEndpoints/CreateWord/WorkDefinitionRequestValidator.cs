using FluentValidation;

namespace EnglishNote.Presentation.Private.WordEndpoints.CreateWord;
internal class WorkDefinitionRequestValidator : AbstractValidator<WorkDefinitionRequest>
{
    public WorkDefinitionRequestValidator()
    {
        RuleFor(x => x.Examples)
            .NotEmpty()
            .Must(x => !x.Any(item => string.IsNullOrEmpty(item)));

        RuleFor(x => x.Antonyms)
            .NotEmpty()
            .Must(x => !x.Any(item => string.IsNullOrEmpty(item)));

        RuleFor(x => x.Synonyms)
            .NotEmpty()
            .Must(x => !x.Any(item => string.IsNullOrEmpty(item)));
    }
}
