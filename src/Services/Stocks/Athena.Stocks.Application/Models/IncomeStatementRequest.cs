namespace Athena.Stocks.WebApi.Models
{
    public class IncomeStatementRequest
    {
        public IncomeStatementRequest(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
    }
}