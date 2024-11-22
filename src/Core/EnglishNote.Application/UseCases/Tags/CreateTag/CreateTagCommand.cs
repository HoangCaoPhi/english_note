using BuildingBlocks;
using BuildingBlocks.Application;

namespace EnglishNote.Application.UseCases.Tags.CreateTag;
public record CreateTagCommand(
    string Name,
    string? Description
) : ICommand<Guid>;