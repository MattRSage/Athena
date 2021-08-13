using System.Threading.Tasks;

namespace Athena.Stocks.Domain.Stocks
{
    public interface IStockRepository
    {
        Task AddAsync(Stock meeting);

        Task<Stock> GetByIdAsync(StockId id);
    }
}