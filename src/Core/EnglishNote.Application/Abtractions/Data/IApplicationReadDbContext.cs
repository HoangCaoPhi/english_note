using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Domain.AggregatesModel.Words;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EnglishNote.Application.Abtractions.Data;
public interface IApplicationReadDbContext 
{
    DatabaseFacade Database { get; }
    IQueryable<Tag> GetTags();
    IQueryable<Word> GetWords();
}
