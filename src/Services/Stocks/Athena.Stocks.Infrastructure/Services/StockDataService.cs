using System.Threading.Tasks;
using Athena.Stocks.Application.Models;
using Athena.Stocks.Application.Services;
using Athena.Stocks.Infrastructure.Api;
using Athena.Stocks.Infrastructure.Mapping;

namespace Athena.Stocks.Infrastructure.Services
{
    public class StockDataService : IStockDataService
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

        public async Task<string> GetStockName(string symbol)
        {
            var response = await _stockDataApi.GetKeyStats(symbol);
            return response.CompanyName;
        }
    }
}