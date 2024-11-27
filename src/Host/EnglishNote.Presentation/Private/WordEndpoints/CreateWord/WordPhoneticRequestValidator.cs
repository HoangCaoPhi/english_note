using FluentValidation;

namespace EnglishNote.Presentation.Private.WordEndpoints.CreateWord;
internal class WordPhoneticRequestValidator : AbstractValidator<WordPhoneticRequest>
{
    public WordPhoneticRequestValidator()
    {
        RuleFor(x => x.Text)
            .NotNull();
    }
}
