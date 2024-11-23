using MediatR;
using Shared;

namespace EnglishNote.Application.Abtractions.Commands;

public interface ICommand : IRequest<Result>;
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;