using Athena.BuildingBlocks.Domain.Entities;
using Athena.Stocks.Domain.Services;
using Athena.Stocks.Domain.StockExchanges;

namespace Athena.Stocks.Domain.Stocks
{
    public class Stock : Entity<StockId>, IAggregateRoot
    {
        public string Symbol { get; }
        public string CompanyName { get; }
        public StockExchangeId StockExchangeId { get; }
        public MoneyValue MarketCap { get; private set; }
        public MoneyValue TotalRevenue { get; private set; }
        public decimal ForwardPeRatio { get; private set; }

        private Stock(string symbol, StockExchangeId stockExchangeId, IStockLookup stockLookup)
        {
            Symbol = symbol;
            StockExchangeId = stockExchangeId;
            CompanyName = stockLookup.GetStockName(symbol).GetAwaiter().GetResult();;
        }

        public static Stock Create(string symbol, StockExchangeId stockExchangeId, IStockLookup stockLookup)
        {
            return new(symbol, stockExchangeId, stockLookup);
        }

        public void UpdateMarketCap(MoneyValue marketCap)
        {
            MarketCap = marketCap;
        }

        public void UpdateTotalRevenue(MoneyValue totalRevenue)
        {
            TotalRevenue = totalRevenue;
        }

        public void UpdateForwardPeRatio(decimal forwardPeRatio)
        {
            ForwardPeRatio = forwardPeRatio;
        }
    }
}