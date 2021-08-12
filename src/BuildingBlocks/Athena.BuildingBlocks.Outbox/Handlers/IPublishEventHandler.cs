using MediatR;

namespace Athena.BuildingBlocks.Outbox.Handlers
{
    public interface IPublishEventHandler<T> : INotificationHandler<T>
        where T : IPublishEvent
    {
    }
}