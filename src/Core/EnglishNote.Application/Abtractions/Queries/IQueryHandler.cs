using MediatR;
using Shared;

namespace EnglishNote.Application.Abtractions.Queries;
public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;