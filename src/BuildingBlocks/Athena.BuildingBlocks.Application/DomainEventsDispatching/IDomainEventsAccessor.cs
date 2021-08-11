using System.Collections.Generic;
using Athena.BuildingBlocks.Domain.Events;

namespace Athena.BuildingBlocks.Application.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}
