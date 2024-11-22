using BuildingBlocks;
using BuildingBlocks.Application;
using EnglishNote.Domain.Tags;

namespace EnglishNote.Application.UseCases.Tags.CreateTag;
internal class CreateTagCommandHandler(ITagRepository tagRepository) : ICommandHandler<CreateTagCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = Tag.CreateTag(request.Name, request.Description, Guid.CreateVersion7());
        tagRepository.Add(tag);
        
        return tag.Id;
    }
}
