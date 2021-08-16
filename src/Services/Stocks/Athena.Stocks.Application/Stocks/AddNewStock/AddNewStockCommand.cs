using System;
using Athena.BuildingBlocks.Application;
using Athena.Stocks.Application.Contracts;

namespace Athena.Stocks.Application.Stocks.AddNewStock
{
    public class AddNewStockCommand : CommandBase<Guid>
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