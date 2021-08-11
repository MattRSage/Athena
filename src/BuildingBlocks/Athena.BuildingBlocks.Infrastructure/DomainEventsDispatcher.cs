using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Application.DomainEventsDispatching;
using MediatR;

namespace Athena.BuildingBlocks.Infrastructure
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator mediator;
        private readonly IDomainEventsAccessor domainEventsProvider;

        public DomainEventsDispatcher(
            IMediator mediator,
            IDomainEventsAccessor domainEventsProvider)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
            this.domainEventsProvider = domainEventsProvider ?? throw new ArgumentNullException(nameof(domainEventsProvider)); ;
        }

        public async Task DispatchEvents(CancellationToken cancellationToken = default)
        {
            while (domainEventsProvider.GetAllDomainEvents().Any())
            {
                var domainEvents = domainEventsProvider.GetAllDomainEvents();

                domainEventsProvider.ClearAllDomainEvents();

                foreach (var domainEvent in domainEvents)
                {
                    await mediator.Publish(domainEvent, cancellationToken);
                }
            }
        }
    }
}
