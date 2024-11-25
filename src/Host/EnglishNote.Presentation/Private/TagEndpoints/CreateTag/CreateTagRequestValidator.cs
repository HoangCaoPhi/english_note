using FluentValidation;

namespace EnglishNote.Presentation.Private.TagEndpoints.CreateTag;
internal sealed class CreateTagRequestValidator : AbstractValidator<CreateTagRequest>
{
    public CreateTagRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
    }
}
