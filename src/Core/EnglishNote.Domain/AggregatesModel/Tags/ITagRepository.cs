namespace EnglishNote.Domain.AggregatesModel.Tags;
public interface ITagRepository
{
    Task AddAsync(Tag tag);
}
