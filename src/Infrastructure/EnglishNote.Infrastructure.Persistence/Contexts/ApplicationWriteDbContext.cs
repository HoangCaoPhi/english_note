using EnglishNote.Domain.Identity;
using EnglishNote.Domain.QuizSessions;
using EnglishNote.Domain.Tags;
using EnglishNote.Domain.Users;
using EnglishNote.Domain.VocabularySets;
using EnglishNote.Domain.Words;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
