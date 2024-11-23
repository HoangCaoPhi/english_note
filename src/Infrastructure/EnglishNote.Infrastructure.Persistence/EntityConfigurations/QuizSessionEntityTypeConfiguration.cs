using EnglishNote.Domain.AggregatesModel.QuizSessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class QuizSessionEntityTypeConfiguration : IEntityTypeConfiguration<QuizSession>
{
    public void Configure(EntityTypeBuilder<QuizSession> builder)
    { 
        builder.Property(qs => qs.StartTime)
            .IsRequired();

        builder.Property(qs => qs.Score)
            .IsRequired();

        builder.Property(qs => qs.CorrectAnswers)
            .IsRequired();

        builder.Property(qs => qs.TotalQuestions)
            .IsRequired();

        builder.Property(qs => qs.Status)
            .IsRequired();
 
        builder.HasOne(qs => qs.VocabularySet)
               .WithOne(vs => vs.QuizSession)
               .HasForeignKey<QuizSession>(qs => qs.VocabularySetId)
               .OnDelete(DeleteBehavior.Restrict);   
    }
}
