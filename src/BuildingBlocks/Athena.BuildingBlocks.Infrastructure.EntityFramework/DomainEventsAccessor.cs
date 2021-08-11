using System;
using System.Collections.Generic;
using System.Linq;
using Athena.BuildingBlocks.Application.DomainEventsDispatching;
using Athena.BuildingBlocks.Domain.Entities;
using Athena.BuildingBlocks.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Athena.BuildingBlocks.Infrastructure.EntityFramework
{
    public class DomainEventsAccessor<T> : IDomainEventsAccessor
            where T : DbContext
    {
        private readonly DbContext dbContext;

        public DomainEventsAccessor(T dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
        }

        public List<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = this.dbContext.ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = this.dbContext.ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}
