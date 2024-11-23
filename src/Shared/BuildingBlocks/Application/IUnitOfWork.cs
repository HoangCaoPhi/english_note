using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BuildingBlocks.Application;
public interface IUnitOfWork
{
    DatabaseFacade Database { get; }

    IDbContextTransaction GetCurrentTransaction();

    Task CommitTransactionAsync(IDbContextTransaction transaction);

    Task<IDbContextTransaction> BeginTransactionAsync();

    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
