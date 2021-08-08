using System.Text.Json.Serialization;

namespace Athena.Stocks.Infrastructure.Api.Responses
{
    public record AdvancedStatsResponse
    {
        [JsonPropertyName("marketcap")]
        public long MarketCap { get; set; }
        
        [JsonPropertyName("totalRevenue")]
        public long TotalRevenue { get; set; }

        [JsonPropertyName("forwardPERatio")]
        public decimal ForwardPeRatio { get; set; }
    }
}