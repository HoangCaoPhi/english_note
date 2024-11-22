using EnglishNote.Domain.Tags;

namespace EnglishNote.Application.Data;
public interface IApplicationReadDbContextContext
{
    IQueryable<Tag> GetTags(); 
}
