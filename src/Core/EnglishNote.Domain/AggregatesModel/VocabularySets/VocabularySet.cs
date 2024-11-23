using EnglishNote.Domain.AggregatesModel.Identity;
using EnglishNote.Domain.AggregatesModel.QuizSessions;
using EnglishNote.Domain.AggregatesModel.Words;
using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.VocabularySets;

public class VocabularySet : AggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public QuizSession QuizSession { get; private set; }
    public Guid QuizSessionId { get; private set; }

    public string? ThumbnailId { get; private set; }

    private readonly List<Word> _words = [];
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    private VocabularySet() { }

    public VocabularySet(string name, Guid userId, ApplicationUser user, string? description = null, string? thumbnailId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        UserId = userId;
        User = user;
        ThumbnailId = thumbnailId;
    }

    public void AddWord(Word word)
    {
        if (!_words.Contains(word))
        {
            _words.Add(word);
        }
    }

    public void RemoveWord(Word word)
    {
        _words.Remove(word);
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public void UpdateThumbnail(string? thumbnailId)
    {
        ThumbnailId = thumbnailId;
    }
}
