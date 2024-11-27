using EnglishNote.Application.Abtractions;
using EnglishNote.Application.Abtractions.Authentication;
using EnglishNote.Application.Abtractions.Commands;
using EnglishNote.Domain.AggregatesModel.Words;
using Shared;

namespace EnglishNote.Application.UseCases.Words.CreateWord;
internal sealed class CreateWordCommandHandler(IGuidGenerator guidGenerator,
    IIdentityService identityService,
    IWordRepository wordRepository) : ICommandHandler<CreateWordCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateWordCommand request, CancellationToken cancellationToken)
    {
        var word = Word.Create(id: guidGenerator.NewGuid(),
            wordText: request.WordText,
            tagId: null,
            vocabularySetId: null,
            userId: identityService.GetUserIdentity(),
            null);

        foreach (var item in request.Phonetics)
        {
            word.AddPhonetic(item.Text, item.Audio, item.CustomAudio);
        }

        foreach (var meaning in request.Meanings)
        {
            if(meaning is null) continue;

            var mean = word.CreateAndAddMeaning(meaning.PartOfSpeech, meaning.CefrLevel);

            foreach (var definition in meaning.Definitions)
            {
                if(definition is null) continue;

                word.AddDefinition(mean, 
                    definition.DefinitionText, 
                    definition.Synonyms, 
                    definition.Antonyms, 
                    definition.Examples);
            }
        }

        await wordRepository.AddAsync(word, cancellationToken);
        return word.Id;
    }
}
