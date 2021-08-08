using System.Collections.Generic;
using Athena.BuildingBlocks.Domain.Events;

namespace Athena.BuildingBlocks.Domain.Entities
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}