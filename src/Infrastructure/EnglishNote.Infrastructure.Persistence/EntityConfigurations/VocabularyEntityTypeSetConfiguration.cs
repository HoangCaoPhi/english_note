using EnglishNote.Domain.AggregatesModel.VocabularySets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishNote.Infrastructure.Persistence.EntityConfigurations;
internal sealed class VocabularyEntityTypeSetConfiguration : IEntityTypeConfiguration<VocabularySet>
{
    public void Configure(EntityTypeBuilder<VocabularySet> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder
             .Property(x => x.Description)
             .HasMaxLength(512);

        builder
             .Property(x => x.ThumbnailId)
             .HasMaxLength(36);

        builder
            .HasMany(x => x.Words)
            .WithOne(x => x.VocabularySet)
            .HasForeignKey(x => x.VocabularySetId)
            .OnDelete(DeleteBehavior.Restrict) ;

    }
}
