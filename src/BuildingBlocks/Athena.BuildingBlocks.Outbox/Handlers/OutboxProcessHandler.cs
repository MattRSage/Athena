using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Logging;

namespace Athena.BuildingBlocks.Outbox.Handlers
{
    public class OutboxProcessHandler : IPublishEventHandler<TransactionCompleted>
    {
        private readonly ILogger<OutboxProcessHandler> logger;
        private readonly ILifetimeScope lifetimeScope;
        public OutboxProcessHandler(ILogger<OutboxProcessHandler> logger, ILifetimeScope lifetimeScope)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }
        public async Task Handle(TransactionCompleted notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Begin processing outbox for Transaction: {notification.TransactionId} which occurred on {notification.OccuredOn}");

            await using var scope = this.lifetimeScope.BeginLifetimeScope();
            var outboxProcessors = scope.Resolve<IEnumerable<IOutboxProcessor>>();
            foreach (var outboxProcessor in outboxProcessors)
            {
                await outboxProcessor.ProcessOutboxMessagesByTransactionId(notification.TransactionId);
            }

            logger.LogInformation($"Finished processing outbox for Transaction: {notification.TransactionId} which occurred on {notification.OccuredOn}");

        }
    }
}