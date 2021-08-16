using System.Threading.Tasks;
using Athena.Stocks.Domain.Stocks;
using Microsoft.EntityFrameworkCore;

namespace Athena.Stocks.Infrastructure.Domain.Stocks
{
    public class StockRepository : IStockRepository
    {
        private readonly StocksContext _context;

        public StockRepository(StocksContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
        }

        public async Task<Stock> GetByIdAsync(StockId id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}