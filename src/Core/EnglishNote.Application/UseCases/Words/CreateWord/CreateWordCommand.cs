using EnglishNote.Application.Abtractions.Commands;
using EnglishNote.Domain.AggregatesModel.Words;

namespace EnglishNote.Application.UseCases.Words.CreateWord;
public record CreateWordCommand(string WordText,
     List<WordPhoneticRequest> Phonetics,
     List<WordMeaningRequest> Meanings) : ICommand<Guid>;

public record WordPhoneticRequest(string Text,
    string? Audio,
    string? CustomAudio);

public record WordMeaningRequest(PartOfSpeech? PartOfSpeech,
     CefrLevel? CefrLevel,
     List<WorkDefinitionRequest> Definitions);
 
public record WorkDefinitionRequest(string DefinitionText,
     List<string> Synonyms,
     List<string> Antonyms,
     List<string> Examples);