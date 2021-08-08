using System;
using MediatR;

namespace Athena.BuildingBlocks.Domain.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime OccuredOn { get; }
    }
}