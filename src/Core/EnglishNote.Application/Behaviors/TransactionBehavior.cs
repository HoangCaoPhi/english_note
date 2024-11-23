using BuildingBlocks.Application;
using BuildingBlocks.Extentions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EnglishNote.Application.Behaviors;
public class TransactionBehavior<TRequest, TResponse>(
    IUnitOfWork unitOfWork,
    ILogger<TransactionBehavior<TRequest, TResponse>> logger) :
    IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = default(TResponse);
        var typeName = request.GetGenericTypeName();

        try
        {
            var currentTransaction = unitOfWork.GetCurrentTransaction();
            bool hasActiveTransaction = currentTransaction is not null;

            if (hasActiveTransaction)
                return await next();

            var strategy = unitOfWork.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                Guid transactionId;

                await using var transaction = await unitOfWork.BeginTransactionAsync();
                using (logger.BeginScope(new List<KeyValuePair<string, object>> { new("TransactionContext", transaction.TransactionId) }))
                {
                    logger.LogInformation("Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.TransactionId, typeName, request);

                    response = await next();

                    logger.LogInformation("Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

                    await unitOfWork.CommitTransactionAsync(transaction);

                    transactionId = transaction.TransactionId;
                }                
            });

            return response;
        }
        catch (Exception ex)
        {            
            logger.LogError(ex, "Error Handling transaction for {CommandName} ({@Command})", typeName, request);
            throw;
        }
    }
}
