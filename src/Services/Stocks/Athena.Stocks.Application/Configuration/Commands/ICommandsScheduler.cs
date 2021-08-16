using System.Threading.Tasks;
using Athena.Stocks.Application.Contracts;

namespace Athena.Stocks.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}