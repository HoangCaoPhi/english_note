using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Domain.AggregatesModel.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EnglishNote.Infrastructure.Persistence.Contexts;
public class ApplicationReadDbContext(ApplicationWriteDbContext context) : 
    IApplicationReadDbContext
{
    public DatabaseFacade Database => context.Database;

    public IQueryable<Tag> GetTags() => GetEntity<Tag>();

    public IQueryable<TEntity> GetEntity<TEntity>() where TEntity : class
    {
        return context
                .Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();
    }
}
