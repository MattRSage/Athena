using System.Threading.Tasks;
using Athena.Stocks.Infrastructure.Api.Responses;
using Refit;

namespace Athena.Stocks.Infrastructure.Api
{
    public interface IStockBatchDataApi
    {
        [Get("/stock/market/advanced-stats?symbols={symbols}")]
        Task<AdvancedStatsResponse> GetAdvancedStats(string symbols);
    }
}