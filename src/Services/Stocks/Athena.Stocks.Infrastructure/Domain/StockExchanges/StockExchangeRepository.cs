using System.Threading.Tasks;
using Athena.Stocks.Domain.StockExchanges;
using Microsoft.EntityFrameworkCore;

namespace Athena.Stocks.Infrastructure.Domain.StockExchanges
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        private readonly StocksContext _context;

        public StockExchangeRepository(StocksContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StockExchange stockExchange)
        {
            await _context.StockExchanges.AddAsync(stockExchange);
        }

        public async Task<StockExchange> GetByIdAsync(StockExchangeId id)
        {
            return await _context.StockExchanges.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}