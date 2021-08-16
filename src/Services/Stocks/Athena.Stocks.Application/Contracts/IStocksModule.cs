using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;

namespace Athena.Stocks.Application.Contracts
{
    public interface IStocksModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}