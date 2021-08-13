using System;
using Athena.BuildingBlocks.Domain.ValueObjects;

namespace Athena.Stocks.Domain.StockExchanges
{
    public class StockExchangeId : TypedIdValueBase
    {
        public StockExchangeId(Guid value)
            : base(value)
        {
        }
    }
}