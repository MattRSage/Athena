using System.Text.Json.Serialization;

namespace Athena.Stocks.Infrastructure.Api.Responses
{
    public record IncomeStatementResponse
    {
        [JsonPropertyName("reportDate")]
        public string ReportDate { get; init; }
        
        [JsonPropertyName("fiscalQuarter")]
        public int FiscalQuarter { get; init; }
        
        [JsonPropertyName("totalRevenue")]
        public long TotalRevenue { get; init; }
    }
}