using EnglishNote.Application.Abtractions.Authentication;
using EnglishNote.Application.Abtractions.Commands;
using EnglishNote.Domain.AggregatesModel.Tags;
using Shared;

namespace EnglishNote.Application.UseCases.Tags.CreateTag;
internal class CreateTagCommandHandler(
    ITagRepository tagRepository,
    IIdentityService identityService) : ICommandHandler<CreateTagCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = Tag.CreateTag(request.Name, 
            request.Description, 
            identityService.GetUserIdentity());

        await tagRepository.AddAsync(tag);        

        return tag.Id;
    }
}
