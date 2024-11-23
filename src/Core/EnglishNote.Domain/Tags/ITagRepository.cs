namespace EnglishNote.Domain.Tags;
public interface ITagRepository
{
    Task AddAsync(Tag tag);
}
