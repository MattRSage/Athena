using System;
using System.Threading;
using System.Threading.Tasks;
using Athena.Stocks.Application.Configuration.Commands;
using Athena.Stocks.Domain.Services;
using Athena.Stocks.Domain.StockExchanges;
using Athena.Stocks.Domain.Stocks;

namespace Athena.Stocks.Application.Stocks.AddNewStock
{
    public class AddNewStockCommandHandler : ICommandHandler<AddNewStockCommand, Guid>
    {
        private readonly IStockExchangeRepository _stockExchangeRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IStockLookup _stockLookup;

        public AddNewStockCommandHandler(IStockExchangeRepository stockExchangeRepository, IStockRepository stockRepository, IStockLookup stockLookup)
        {
            _stockExchangeRepository = stockExchangeRepository;
            _stockRepository = stockRepository;
            _stockLookup = stockLookup;
        }

        public async Task<Guid> Handle(AddNewStockCommand request, CancellationToken cancellationToken)
        {
            var stockExchange = await _stockExchangeRepository.GetByIdAsync(new StockExchangeId(request.StockExchangeId));

            var stock = stockExchange.AddNewStock(_stockLookup, request.Symbol);

            await _stockRepository.AddAsync(stock);

            return stock.Id.Value;
        }
    }
}