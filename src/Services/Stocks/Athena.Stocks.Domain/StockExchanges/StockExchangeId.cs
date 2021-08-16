using System;
using Athena.BuildingBlocks.Domain;

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