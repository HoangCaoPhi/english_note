using EnglishNote.Application.Data;
using EnglishNote.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace EnglishNote.Infrastructure.Persistence.Contexts;
public class ApplicationReadDbContext
    (DbContextOptions<ApplicationReadDbContext> options) : 
    DbContext(options), IApplicationReadDbContextContext
{
    public IQueryable<Tag> GetTags() => Set<Tag>().AsQueryable();
}
