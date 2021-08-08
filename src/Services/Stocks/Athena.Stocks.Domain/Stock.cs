using Athena.BuildingBlocks.Domain.Entities;
using Athena.Stocks.Domain.Services;

namespace Athena.Stocks.Domain
{
    public class Stock : Entity<StockId>, IAggregateRoot
    {
        public string Symbol { get; }
        public string CompanyName { get; }
        public long MarketCap { get; set; }
        public long TotalRevenue { get; set; }
        public decimal ForwardPeRatio { get; set; }

        private Stock(string symbol, IStockLookup stockLookup)
        {
            Symbol = symbol;
            CompanyName = stockLookup.GetStockName(symbol).GetAwaiter().GetResult();;
        }

        public static Stock Create(string symbol, IStockLookup stockLookup)
        {
            return new(symbol, stockLookup);
        }

        public void UpdateMarketCap(long marketCap)
        {
            MarketCap = marketCap;
        }

        public void UpdateTotalRevenue(long totalRevenue)
        {
            TotalRevenue = totalRevenue;
        }

        public void UpdateForwardPeRatio(decimal forwardPeRatio)
        {
            ForwardPeRatio = forwardPeRatio;
        }
    }
}