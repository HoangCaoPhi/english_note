using EnglishNote.Application.Abtractions;
using EnglishNote.Application.Abtractions.Authentication;
using EnglishNote.Application.Abtractions.Commands;
using EnglishNote.Domain.AggregatesModel.Tags;
using Shared;

namespace EnglishNote.Application.UseCases.Tags.CreateTag;
internal class CreateTagCommandHandler(
    ITagRepository tagRepository,
    IIdentityService identityService,
    IGuidGenerator guidGenerator) : ICommandHandler<CreateTagCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = Tag.CreateTag(guidGenerator.NewGuid(),
            request.Name, 
            request.Description, 
            identityService.GetUserIdentity());

        await tagRepository.AddAsync(tag, cancellationToken);        

        return tag.Id;
    }
}
