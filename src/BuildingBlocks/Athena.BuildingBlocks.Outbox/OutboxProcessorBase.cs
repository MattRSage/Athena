using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Telemetry;
using Microsoft.Extensions.Logging;

namespace Athena.BuildingBlocks.Outbox
{
    public abstract class OutboxProcessorBase<T> : IOutboxProcessor<T>
        where T : class
    {
        private readonly IOutboxAccessor outboxAccessor;
        protected readonly IOutboxMapper<T> outboxMapper;
        private readonly ILogger<OutboxProcessorBase<T>> logger;
        private readonly ITelemetryService telemetryService;

        public OutboxProcessorBase(IOutboxAccessor outboxAccessor,
            IOutboxMapper<T> outboxMapper,
            ILogger<OutboxProcessorBase<T>> logger,
            ITelemetryService telemetryService)
        {
            this.outboxAccessor = outboxAccessor ?? throw new ArgumentNullException(nameof(outboxAccessor));
            this.outboxMapper = outboxMapper ?? throw new ArgumentNullException(nameof(outboxMapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.telemetryService = telemetryService ?? throw new ArgumentNullException(nameof(telemetryService));
        }


        public async Task ProcessOutboxMessagesByTransactionId(Guid transactionId)
        {
            var pendingLogEvents = await outboxAccessor.GetUnpublishedOutboxMessagesByTransactionId(transactionId, typeof(T).Name);

            await ProcessOutboxMessages(pendingLogEvents);
        }

        public async Task ProcessOutboxMessages()
        {
            var pendingLogEvents = await outboxAccessor.GetUnpublishedOutboxMessages(typeof(T).Name);

            await ProcessOutboxMessages(pendingLogEvents);
        }

        private async Task ProcessOutboxMessages(IEnumerable<OutboxMessage> outboxMessages)
        {
            foreach (var outboxMessage in outboxMessages)
            {
                var messageToProcess = outboxMapper.Deserialize(outboxMessage);

                logger.LogInformation($"----- Processing message: {outboxMessage.Id} - ({outboxMessage.ShortType})");
                telemetryService.StartDependentOperation($"----- Processing message: {outboxMessage.Id} - ({outboxMessage.ShortType})", outboxMessage.OperationId);
                try
                {
                    await outboxAccessor.MarkOutboxMessageAsInProgress(outboxMessage.Id);
                    await Handle(messageToProcess);
                    await outboxAccessor.MarkOutboxMessageAsProcessed(outboxMessage.Id);
                    logger.LogInformation($"----- Processed message: {outboxMessage.Id} - ({outboxMessage.ShortType})");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"ERROR processing message: {outboxMessage.Id} - ({outboxMessage.ShortType})");
                    await outboxAccessor.MarkOutboxMessageAsFailed(outboxMessage.Id);
                }
                finally
                {
                    telemetryService.StopOperation();
                }
            }
        }

        public abstract Task Handle(T outboxMessage);
    }
}