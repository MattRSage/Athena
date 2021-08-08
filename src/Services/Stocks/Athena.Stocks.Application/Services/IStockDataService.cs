using System.Threading.Tasks;
using Athena.Stocks.Application.Models;

namespace Athena.Stocks.Application.Services
{
    public interface IStockDataService
    {
        Task<IncomeStatementResult> GetIncomeStatement(string symbol);
    }
}