using System;
using Athena.BuildingBlocks.Domain;
using Athena.Stocks.Domain.Services;
using Athena.Stocks.Domain.StockExchanges;

namespace Athena.Stocks.Domain.Stocks
{
    public class Stock : Entity, IAggregateRoot
    {
        public StockId Id { get; private set; }

        private string _symbol;

        private string _companyName;

        private StockExchangeId _stockExchangeId;

        private MoneyValue _marketCap;

        private MoneyValue _totalRevenue;

        private decimal _forwardPeRatio;

        public static Stock AddNew(StockExchangeId stockExchangeId, IStockLookup stockLookup, string symbol)
        {
            return new (symbol, stockExchangeId, stockLookup);
        }

        private Stock()
        {
        }

        private Stock(string symbol, StockExchangeId stockExchangeId, IStockLookup stockLookup)
        {
            Id = new StockId(Guid.NewGuid());
            _symbol = symbol;
            _stockExchangeId = stockExchangeId;
            _companyName = stockLookup.GetStockName(symbol).GetAwaiter().GetResult();
        }

        public void UpdateMarketCap(MoneyValue marketCap)
        {
            _marketCap = marketCap;
        }

        public void UpdateTotalRevenue(MoneyValue totalRevenue)
        {
            _totalRevenue = totalRevenue;
        }

        public void UpdateForwardPeRatio(decimal forwardPeRatio)
        {
            _forwardPeRatio = forwardPeRatio;
        }
    }
}