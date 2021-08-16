using System;
using Athena.BuildingBlocks.Domain;
using Athena.Stocks.Domain.Services;
using Athena.Stocks.Domain.Stocks;

namespace Athena.Stocks.Domain.StockExchanges
{
    public class StockExchange : Entity, IAggregateRoot
    {
        public StockExchangeId Id { get; private set; }

        private string _name;

        private string _exchangeCode;

        public static StockExchange AddNew(string name, string exchangeCode)
        {
            return new StockExchange(name, exchangeCode);
        }

        private StockExchange()
        {
        }

        private StockExchange(string name, string exchangeCode)
        {
            Id = new StockExchangeId(Guid.NewGuid());
            _name = name;
            _exchangeCode = exchangeCode;
        }

        public Stock AddNewStock(IStockLookup stockLookup, string symbol)
        {
            return Stock.AddNew(Id, stockLookup, symbol);
        }
    }
}