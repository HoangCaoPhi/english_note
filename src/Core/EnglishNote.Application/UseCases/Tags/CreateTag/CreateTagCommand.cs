using EnglishNote.Application.Abtractions.Commands;

namespace EnglishNote.Application.UseCases.Tags.CreateTag;
public record CreateTagCommand(
    string Name,
    string? Description
) : ICommand<Guid>;