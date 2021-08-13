using System;
using System.Threading;
using System.Threading.Tasks;
using Athena.BuildingBlocks.Application;
using Athena.Stocks.Domain.StockExchanges;
using MediatR;

namespace Athena.Stocks.Application.AddNewStockExchange
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
            var stockExchange = StockExchange.AddNew(request.Name);

            await _stockExchangeRepository.AddAsync(stockExchange);

            return stockExchange.Id.Value;
        }
    }
}