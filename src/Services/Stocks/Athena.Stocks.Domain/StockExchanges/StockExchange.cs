using Athena.BuildingBlocks.Domain.Entities;
using Athena.Stocks.Domain.Services;
using Athena.Stocks.Domain.Stocks;

namespace Athena.Stocks.Domain.StockExchanges
{
    public class StockExchange : Entity<StockExchangeId>, IAggregateRoot
    {
        private string _name;

        public static StockExchange AddNew(string name)
        {
            return new StockExchange(name);
        }

        private StockExchange()
        {
        }

        private StockExchange(string name)
        {
            _name = name;
        }

        public Stock AddNewStock(IStockLookup stockLookup, string symbol)
        {
            return Stock.AddNew(Id, stockLookup, symbol);
        }
    }
}