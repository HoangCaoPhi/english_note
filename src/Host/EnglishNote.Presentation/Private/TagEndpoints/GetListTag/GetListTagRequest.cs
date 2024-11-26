using EnglishNote.Application.Abtractions.Queries;

namespace EnglishNote.Presentation.Private.TagEndpoints.GetListTag;

public class GetListTagRequest : PagingModel 
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}
