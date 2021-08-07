using System.Threading.Tasks;
using Athena.Stocks.Infrastructure.Api;
using Athena.Stocks.Infrastructure.Mapping;
using Athena.Stocks.WebApi.Models;

namespace Athena.Stocks.Infrastructure.Services
{
    public class StockDataService
    {
        private readonly IStockDataApi _stockDataApi;

        public StockDataService(IStockDataApi stockDataApi)
        {
            _stockDataApi = stockDataApi;
        }

        public async Task<IncomeStatementResult> GetIncomeStatement(string symbol)
        {
            var response = await _stockDataApi.GetIncomeStatement(symbol);
            return response.ToIncomeStatementResult();
        }
    }
}