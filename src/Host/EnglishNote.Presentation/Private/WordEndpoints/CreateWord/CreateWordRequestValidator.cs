using FluentValidation;

namespace EnglishNote.Presentation.Private.WordEndpoints.CreateWord;
internal sealed class CreateWordRequestValidator : AbstractValidator<CreateWordRequest>
{
    public CreateWordRequestValidator()
    {
        RuleFor(x => x.WordText)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Phonetics)
            .Must(phonetics => phonetics is not null && phonetics.Count > 0)
            .WithMessage("The list of phonetics must conataina at least one item")
            .ForEach(phonetic => phonetic.SetValidator(new WordPhoneticRequestValidator()));

        RuleFor(word => word.Meanings)
             .Must(meanings => meanings != null && meanings.Count > 0)
             .WithMessage("The list of meanings must contain at least one item.")
             .ForEach(mean => mean.SetValidator(new WordMeaningRequestValidator()));
    }
}
