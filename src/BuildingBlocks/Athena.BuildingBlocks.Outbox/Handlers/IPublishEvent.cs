using System;
using MediatR;

namespace Athena.BuildingBlocks.Outbox.Handlers
{
    public interface IPublishEvent : INotification
    {
        DateTime OccuredOn { get; }
    }
}