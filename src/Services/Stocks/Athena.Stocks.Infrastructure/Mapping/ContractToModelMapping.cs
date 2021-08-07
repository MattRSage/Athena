using Athena.Stocks.Infrastructure.Api.Responses;
using Athena.Stocks.WebApi.Models;

namespace Athena.Stocks.Infrastructure.Mapping
{
    public static class ContractToModelMapping
    {
        public static IncomeStatementResult ToIncomeStatementResult(this IncomeStatementResponse response)
        {
            return new()
            {
                ReportDate = response.ReportDate,
                FiscalQuarter = response.FiscalQuarter,
                TotalRevenue = response.TotalRevenue
            };
        }
    }
}