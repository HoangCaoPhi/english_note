using EnglishNote.Domain.Users;

namespace EnglishNote.Domain.QuizSessions;
public class QuizSession
{
    public Guid Íd { get; set; }   
    public Guid VocabularySetId { get; set; } 
    public DateTime StartTime { get; set; }  
    public DateTime? EndTime { get; set; } 
    public int Score { get; set; }  
    public int CorrectAnswers { get; set; }  
    public int TotalQuestions { get; set; } 
    public QuizSessionStatus Status { get; set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }
}