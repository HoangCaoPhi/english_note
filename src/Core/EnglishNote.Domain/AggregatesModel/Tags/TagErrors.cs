namespace EnglishNote.Domain.AggregatesModel.Tags;
public sealed class TagErrors
{
    public static Error NotFound
        => Error.NotFound("Tag.NotFound", "Tag not found");
}
