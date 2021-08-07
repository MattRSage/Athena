namespace Athena.Stocks.WebApi.Models
{
    public record IncomeStatementResult
    {
        public string ReportDate { get; init; }
        public int FiscalQuarter { get; init; }
        public long TotalRevenue { get; init; }
    }
}