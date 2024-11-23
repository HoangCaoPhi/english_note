using EnglishNote.Domain.AggregatesModel.Identity;
using EnglishNote.Domain.AggregatesModel.VocabularySets;
using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.QuizSessions;

public class QuizSession : AggregateRoot
{
    public Guid VocabularySetId { get; private set; }
    public VocabularySet VocabularySet { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public int Score { get; private set; }
    public int CorrectAnswers { get; private set; }
    public int TotalQuestions { get; private set; }
    public QuizSessionStatus Status { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    private QuizSession() { }

    public QuizSession(Guid vocabularySetId, VocabularySet vocabularySet, Guid userId, ApplicationUser user, int totalQuestions)
    {
        Id = Guid.CreateVersion7();
        VocabularySetId = vocabularySetId;
        VocabularySet = vocabularySet;
        UserId = userId;
        User = user;
        TotalQuestions = totalQuestions;
        StartTime = DateTime.UtcNow;
        Status = QuizSessionStatus.InProgress;
    }

    public void CompleteSession(int correctAnswers, int score)
    {
        CorrectAnswers = correctAnswers;
        Score = score;
        EndTime = DateTime.UtcNow;
        Status = QuizSessionStatus.Completed;
    }

    public void UpdateScore(int correctAnswers)
    {
        CorrectAnswers += correctAnswers;
        Score = CalculateScore();
    }

    private int CalculateScore()
    {
        return (int)Math.Round((double)(CorrectAnswers * 100) / TotalQuestions);
    }
}
