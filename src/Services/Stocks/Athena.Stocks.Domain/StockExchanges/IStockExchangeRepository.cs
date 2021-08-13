using System.Threading.Tasks;

namespace Athena.Stocks.Domain.StockExchanges
{
    public interface IStockExchangeRepository
    {
        Task AddAsync(StockExchange stockExchange);

        Task<StockExchange> GetByIdAsync(StockExchangeId id);
    }
}