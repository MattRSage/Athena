using System;
using System.Threading;
using System.Threading.Tasks;
using Athena.Stocks.Application.Configuration.Commands;
using Athena.Stocks.Domain.StockExchanges;

namespace Athena.Stocks.Application.StockExchanges.AddNewStockExchange
{
    public class AddNewStockExchangeCommandHandler : ICommandHandler<AddNewStockExchangeCommand, Guid>
    {
        private readonly IStockExchangeRepository _stockExchangeRepository;

        public AddNewStockExchangeCommandHandler(IStockExchangeRepository stockExchangeRepository)
        {
            _stockExchangeRepository = stockExchangeRepository;
        }

        public async Task<Guid> Handle(AddNewStockExchangeCommand request, CancellationToken cancellationToken)
        {
            var stockExchange = StockExchange.AddNew(request.Name, request.ExchangeCode);

            await _stockExchangeRepository.AddAsync(stockExchange);

            return stockExchange.Id.Value;
        }
    }
}