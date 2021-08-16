using System;

namespace Athena.API.Modules.Stocks.Stocks
{
    public class AddStockRequest
    {
        public Guid StockExchangeId { get; set; }

        public string Symbol { get; set; }
    }
}