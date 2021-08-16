using System;
using Athena.BuildingBlocks.Domain;

namespace Athena.Stocks.Domain.Stocks
{
    public class StockId : TypedIdValueBase
    {
        public StockId(Guid value)
            : base(value)
        {
        }
    }
}