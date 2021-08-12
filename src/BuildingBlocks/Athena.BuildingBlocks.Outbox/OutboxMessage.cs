using System;
using System.Linq;

namespace Athena.BuildingBlocks.Outbox
{
    public class OutboxMessage
    {
        private OutboxMessage() { }
        public OutboxMessage(Guid id, DateTime occurredOn, string type, string data, string operationId, string outboxType, int maxRetries = int.MaxValue)
        {
            Id = id;
            OccuredOn = occurredOn;
            Type = type;
            Data = data;
            State = OutboxStateEnum.Unprocessed;
            TimesSent = 0;
            OperationId = operationId;
            OutboxType = outboxType;
            MaxRetries = maxRetries;
        }
        public Guid Id { get; private set; }
        public string Type { get; private set; }
        public string ShortType => Type.Split('.')?.Last();
        public OutboxStateEnum State { get; set; }
        public int TimesSent { get; set; }
        public DateTime OccuredOn { get; private set; }
        public string Data { get; private set; }
        public string TransactionId { get; set; }
        public string OperationId { get; private set; }
        public string OutboxType { get; private set; }
        public int MaxRetries { get; private set; }
    }
}