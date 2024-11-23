using MediatR;
using Shared;

namespace EnglishNote.Application.Abtractions.Queries;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;