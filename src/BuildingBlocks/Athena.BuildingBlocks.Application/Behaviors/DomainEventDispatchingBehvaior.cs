using System;
using System.Threading;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Application.DomainEventsDispatching;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Athena.BuildingBlocks.Application.Behaviors
{
    public class DomainEventDispatchingBehvaior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
    {
        private IDomainEventsDispatcher domainEventsDispatcher;
        private readonly ILogger<TRequest> logger;

        public DomainEventDispatchingBehvaior(IDomainEventsDispatcher domainEventsDispatcher, ILogger<TRequest> logger)
        {
            this.domainEventsDispatcher = domainEventsDispatcher ?? throw new ArgumentNullException(nameof(domainEventsDispatcher));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var reponse = await next();
            await domainEventsDispatcher.DispatchEvents(cancellationToken);

            return reponse;
        }
    }
}
