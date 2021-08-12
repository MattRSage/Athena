using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Outbox;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Athena.BuildingBlocks.Application.Behaviors
{
    public class UnitOfWorkTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
    {
        private readonly ILogger<TRequest> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOutboxProcessDispatcher outboxProcessDispatcher;

        public UnitOfWorkTransactionBehavior(
            ILogger<TRequest> logger,
            IUnitOfWork unitOfWork,
            IOutboxProcessDispatcher outboxProcessDispatcher)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.outboxProcessDispatcher = outboxProcessDispatcher ?? throw new ArgumentNullException(nameof(outboxProcessDispatcher));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var name = typeof(TRequest).Name;

            var transactionId = await unitOfWork.BeginTransaction();
            logger.LogInformation($"Begin Transaction: {name} {request} {transactionId}");

            var response = await next();

            logger.LogInformation($"Completing Transaction: {name} {request} {transactionId}");
            await unitOfWork.Complete(cancellationToken);
            logger.LogInformation($"Completed Transaction: {name} {request} {transactionId}");

            logger.LogInformation($"Begin call to IOutboxProcessDispatcher for Transaction: {transactionId} at {DateTime.UtcNow}");

            await this.outboxProcessDispatcher.DispatchProcessOutboxMessages(new TransactionCompleted(transactionId, DateTime.UtcNow)).ConfigureAwait(false);

            logger.LogInformation($"End call to IOutboxProcessDispatcher for Transaction: {transactionId} at {DateTime.UtcNow}");

            return response;
        }
    }
}
