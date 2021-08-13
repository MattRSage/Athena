using System;
using Athena.BuildingBlocks.Application;

namespace Athena.Stocks.Application.AddNewStockExchange
{
    public class AddNewStockExchangeCommand : ICommand<Guid>
    {
        public AddNewStockExchangeCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}