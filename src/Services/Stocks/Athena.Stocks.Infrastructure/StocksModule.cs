using System.Threading.Tasks;
using Athena.Stocks.Application.Contracts;
using Athena.Stocks.Infrastructure.Configuration;
using Athena.Stocks.Infrastructure.Configuration.Processing;
using Autofac;
using MediatR;

namespace Athena.Stocks.Infrastructure
{
    public class StocksModule : IStocksModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = StocksCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}