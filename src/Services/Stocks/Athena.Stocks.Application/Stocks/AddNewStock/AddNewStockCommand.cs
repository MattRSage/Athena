using System;
using Athena.BuildingBlocks.Application;

namespace Athena.Stocks.Application.Stocks.AddNewStock
{
    public class AddNewStockCommand : ICommand<Guid>
    {
        public AddNewStockCommand(Guid stockExchangeId, string symbol)
        {
            StockExchangeId = stockExchangeId;
            Symbol = symbol;
        }

        public Guid StockExchangeId { get; }

        public string Symbol { get; }
    }
}