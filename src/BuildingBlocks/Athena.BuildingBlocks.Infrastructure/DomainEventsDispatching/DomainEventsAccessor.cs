using System.Collections.Generic;
using System.Linq;
using Athena.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;

namespace Athena.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _stocksContext;

        public DomainEventsAccessor(DbContext stocksContext)
        {
            _stocksContext = stocksContext;
        }

        public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = this._stocksContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = this._stocksContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}