using System;
using Athena.Stocks.Application.Contracts;

namespace Athena.Stocks.Application.StockExchanges.AddNewStockExchange
{
    public class AddNewStockExchangeCommand : CommandBase<Guid>
    {
        public AddNewStockExchangeCommand(string name, string exchangeCode)
        {
            Name = name;
            ExchangeCode = exchangeCode;
        }

        public string Name { get; }

        public string ExchangeCode { get; }
    }
}