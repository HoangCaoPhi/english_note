namespace EnglishNote.Application.UseCases.Tags.GetOneTag;
public record GetOneTagViewModel(
    Guid Id,
    string Name,
    string? Description,
    Guid UserId);