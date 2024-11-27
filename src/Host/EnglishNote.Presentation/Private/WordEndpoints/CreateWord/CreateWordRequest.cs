using EnglishNote.Domain.AggregatesModel.Words;

namespace EnglishNote.Presentation.Private.WordEndpoints.CreateWord;
public record CreateWordRequest(string WordText,
     List<WordPhoneticRequest> Phonetics,
     List<WordMeaningRequest> Meanings);

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