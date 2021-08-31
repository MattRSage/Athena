using System.Text.Json.Serialization;

namespace Athena.Stocks.Infrastructure.Api.Responses
{
    public class KeyStatsResponse
    {
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("marketcap")]
        public long MarketCap { get; set; }
    }
}