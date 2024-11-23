using BuildingBlocks.Application;

namespace EnglishNote.Application.UseCases.Tags.GetOneTag;
public record GetOneTagQuery(Guid TagId) : IQuery<GetOneTagViewModel>;