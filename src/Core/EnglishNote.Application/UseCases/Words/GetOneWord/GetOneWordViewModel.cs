using EnglishNote.Domain.AggregatesModel.Words;

namespace EnglishNote.Application.UseCases.Words.GetOneWord;

public record GetOneWordViewModel(string WordText,
     List<WordPhoneticViewModel> Phonetics,
     List<WordMeaningViewModel> Meanings);

public record WordPhoneticViewModel(string Text,
    string? Audio,
    string? CustomAudio);

public record WordMeaningViewModel(PartOfSpeech? PartOfSpeech,
     CefrLevel? CefrLevel,
     List<WorkDefinitionViewModel> Definitions);

public record WorkDefinitionViewModel(string DefinitionText,
     List<string> Synonyms,
     List<string> Antonyms,
     List<string> Examples);