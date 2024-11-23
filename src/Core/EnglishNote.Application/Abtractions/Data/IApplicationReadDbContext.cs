using EnglishNote.Domain.Tags;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EnglishNote.Application.Abtractions.Data;
public interface IApplicationReadDbContext 
{
    DatabaseFacade Database { get; }
    IQueryable<Tag> GetTags();
}
