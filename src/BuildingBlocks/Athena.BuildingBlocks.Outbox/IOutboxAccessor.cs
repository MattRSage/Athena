using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athena.BuildingBlocks.Outbox
{
    public interface IOutboxAccessor
    {
        Task<IEnumerable<OutboxMessage>> GetUnpublishedOutboxMessages(string outboxType);

        Task<IEnumerable<OutboxMessage>> GetUnpublishedOutboxMessagesByTransactionId(Guid transactionId, string outboxType);

        Task MarkOutboxMessageAsProcessed(Guid id);

        Task MarkOutboxMessageAsInProgress(Guid id);

        Task MarkOutboxMessageAsFailed(Guid id);
    }
}