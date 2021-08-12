using System;
using System.Threading.Tasks;

namespace Athena.BuildingBlocks.Outbox
{
    public interface IOutboxProcessor<T> : IOutboxProcessor
        where T : class
    {

    }

    public interface IOutboxProcessor
    {
        Task ProcessOutboxMessagesByTransactionId(Guid transactionId);

        Task ProcessOutboxMessages();
    }
}