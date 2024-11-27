using EnglishNote.Domain.AggregatesModel.Words;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishNote.Infrastructure.Persistence.EntityConfigurations;
internal sealed class WordEntityTypeConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
       builder
            .Property(x => x.WordText)
            .HasMaxLength(512)
            .IsRequired();

        builder
             .Property(x => x.MemoryLevel)
             .HasConversion<string>()
             .HasMaxLength(50);

        builder
             .OwnsMany(x => x.Phonetics, phoneticBuilder =>
             {
                 phoneticBuilder.Property(x => x.Text)
                   .IsRequired()
                   .HasMaxLength(500);

                 phoneticBuilder.Property(x => x.Audio)
                   .HasMaxLength(500);

                 phoneticBuilder.Property(x => x.CustomAudio)
                   .HasMaxLength(36);
             });

        builder
            .OwnsMany(x => x.Meanings, meaningBuilder =>
            {
                meaningBuilder
                    .Property(x => x.CefrLevel)
                    .HasConversion<string>()
                    .HasMaxLength(10);

                meaningBuilder
                    .Property(x => x.PartOfSpeech)
                    .HasConversion<string>()
                    .HasMaxLength(50);

                meaningBuilder
                    .OwnsMany(x => x.Definitions, definitionBuilder =>
                    {
                        definitionBuilder
                            .Property(x => x.DefinitionText)
                            .IsRequired()
                            .HasMaxLength(1024);

                        definitionBuilder
                            .OwnsMany(x => x.Examples, exampleBuilder =>
                            {
                                exampleBuilder
                                .Property(x => x.Value)
                                .IsRequired()
                                .HasMaxLength(1024);
                            });

                        definitionBuilder
                            .OwnsMany(x => x.Antonyms, antonymsBuilder =>
                            {
                                antonymsBuilder
                                    .Property(x => x.Value)
                                    .IsRequired()
                                    .HasMaxLength(126);
                            });

                        definitionBuilder
                            .OwnsMany(x => x.Synonyms, synonymsBuilder =>
                            {
                                synonymsBuilder
                                .Property(x => x.Value)
                                .IsRequired()
                                .HasMaxLength(126);
                            });
                    });
            });
    }
}
