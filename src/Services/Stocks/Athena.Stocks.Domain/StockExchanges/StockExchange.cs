using Athena.BuildingBlocks.Domain.Entities;

namespace Athena.Stocks.Domain.StockExchanges
{
    public class StockExchange : Entity<StockExchangeId>, IAggregateRoot
    {
        public string Name { get; }

        private StockExchange(string name)
        {
            Name = name;
        }
    }
}