using System;
using System.Threading;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Outbox.Publisher;

namespace Athena.BuildingBlocks.Outbox
{
    public class OutboxProcessDispatcher : IOutboxProcessDispatcher
    {
        private readonly Publisher.Publisher publisher;
        private readonly bool runParallelNoWait;

        public OutboxProcessDispatcher(Publisher.Publisher publisher, bool runParallelNoWait = true)
        {
            this.publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            this.runParallelNoWait = runParallelNoWait;
        }

        public async Task DispatchProcessOutboxMessages(TransactionCompleted request, CancellationToken cancellationToken = default)
        {
            await this.publisher.Publish(request, runParallelNoWait ? PublishStrategy.ParallelNoWait : PublishStrategy.SyncStopOnException, cancellationToken);
        }
    }
}