using System.Threading.Tasks;

namespace Athena.Stocks.Domain.Stocks
{
    public interface IStockRepository
    {
        Task AddAsync(Stock stock);

        Task<Stock> GetByIdAsync(StockId id);
    }
}