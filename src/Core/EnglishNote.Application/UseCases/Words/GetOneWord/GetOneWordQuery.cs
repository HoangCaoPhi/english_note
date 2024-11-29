using EnglishNote.Application.Abtractions.Queries;

namespace EnglishNote.Application.UseCases.Words.GetOneWord;
public record GetOneWordQuery(Guid Id) : IQuery<GetOneWordViewModel>;
