using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Domain.AggregatesModel.Words;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EnglishNote.Infrastructure.Persistence.Contexts;
public class ApplicationReadDbContext(ApplicationWriteDbContext context) : 
    IApplicationReadDbContext
{
    public DatabaseFacade Database => context.Database;

    public IQueryable<TEntity> GetEntity<TEntity>() where TEntity : class
    {
        return context
                .Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();
    }

    public IQueryable<Tag> GetTags() => GetEntity<Tag>();
    public IQueryable<Word> GetWords() => GetEntity<Word>();
}
