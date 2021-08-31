using System.Threading.Tasks;
using Athena.Stocks.Infrastructure.Api.Responses;
using Refit;

namespace Athena.Stocks.Infrastructure.Api
{
    public interface IStockDataApi
    {
        [Get("/stock/{symbol}/income")]
        Task<IncomeStatementResponse> GetIncomeStatement(string symbol);

        [Get("/stock/{symbol}/stats")]
        Task<KeyStatsResponse> GetKeyStats(string symbol);

        [Get("/stock/{symbol}/advanced-stats")]
        Task<AdvancedStatsResponse> GetAdvancedStats(string symbol);
    }
}