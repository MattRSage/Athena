using System.Collections.Generic;

namespace Athena.Stocks.Infrastructure.Api.Responses
{
    public record BatchAdvancedStatsResponse
    {
        public IReadOnlyList<AdvancedStatsResponse> AdvancedStats { get; init; }
    }
}