using EnglishNote.Domain.AggregatesModel.Identity;
using EnglishNote.Domain.AggregatesModel.QuizSessions;
using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Domain.AggregatesModel.VocabularySets;
using EnglishNote.Domain.AggregatesModel.Words;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnglishNote.Infrastructure.Persistence.Contexts;

public class ApplicationWriteDbContext(
    DbContextOptions<ApplicationWriteDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<Word> Words { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<VocabularySet> VocabularySets { get; set; }

    public DbSet<QuizSession> QuizSessions { get; set; }

  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
        base.OnModelCreating(builder);
    }
}
