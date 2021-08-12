using System;
using Athena.BuildingBlocks.Outbox.Handlers;

namespace Athena.BuildingBlocks.Outbox
{
    public class TransactionCompleted : IPublishEvent
    {
        public TransactionCompleted(Guid transactionId, DateTime occuredOn)
        {
            this.OccuredOn = occuredOn;
            this.TransactionId = transactionId;
        }
        public Guid TransactionId { get; }

        public DateTime OccuredOn { get; }
    }
}