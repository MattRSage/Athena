using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MediatR;

namespace Athena.BuildingBlocks.Application
{
    public class RequestExecutor : IRequestExecutor
    {
        private readonly IMediator mediator;
        private readonly ILifetimeScope _lifetimeScope;

        public RequestExecutor(IMediator mediator, ILifetimeScope lifetimeScope)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public async Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            await using var scope = _lifetimeScope.BeginLifetimeScope();
            return await mediator.Send(command, cancellationToken);
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(query, cancellationToken);
        }
    }
}
