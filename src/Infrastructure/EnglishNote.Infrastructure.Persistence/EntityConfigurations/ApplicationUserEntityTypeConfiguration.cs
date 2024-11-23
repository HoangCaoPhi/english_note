using EnglishNote.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishNote.Infrastructure.Persistence.EntityConfigurations;
internal sealed class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FirstName)
                .HasMaxLength(100);

        builder.Property(x => x.LastName)
                .HasMaxLength(100);

        builder.HasMany(x => x.VocabularySets)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId);


        builder.HasMany(x => x.Tags)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Words)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
