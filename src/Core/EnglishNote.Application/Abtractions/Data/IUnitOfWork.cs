using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EnglishNote.Application.Abtractions.Data;
public interface IUnitOfWork
{
    DatabaseFacade Database { get; }

    IDbContextTransaction GetCurrentTransaction();

    Task CommitTransactionAsync(IDbContextTransaction transaction);

    Task<IDbContextTransaction> BeginTransactionAsync();

    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
