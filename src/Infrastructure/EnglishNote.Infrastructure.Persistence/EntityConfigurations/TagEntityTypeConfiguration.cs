using EnglishNote.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishNote.Infrastructure.Persistence.EntityConfigurations;
internal sealed class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(512);

        builder
            .HasMany(x => x.Words)
            .WithOne(x => x.Tag)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
