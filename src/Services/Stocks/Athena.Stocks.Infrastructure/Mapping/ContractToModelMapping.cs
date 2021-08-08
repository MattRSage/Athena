using Athena.Stocks.Application.Models;
using Athena.Stocks.Infrastructure.Api.Responses;

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