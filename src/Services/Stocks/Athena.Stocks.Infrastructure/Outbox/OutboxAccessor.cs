using System.Threading.Tasks;
using Athena.BuildingBlocks.Application.Outbox;

namespace Athena.Stocks.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly StocksContext _stocksContext;

        internal OutboxAccessor(StocksContext stocksContext)
        {
            _stocksContext = stocksContext;
        }

        public void Add(OutboxMessage message)
        {
            _stocksContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}