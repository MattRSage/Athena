using System.Threading.Tasks;
using Athena.BuildingBlocks.Application;
using Athena.Stocks.Application.Contracts;
using Athena.Stocks.Application.StockExchanges.AddNewStockExchange;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athena.API.Modules.Stocks.StockExchanges
{
    [Route("api/stocks/[controller]")]
    [ApiController]
    public class StockExchangesController : ControllerBase
    {
        private readonly IStocksModule _stocksModule;

        public StockExchangesController(IStocksModule stocksModule)
        {
            _stocksModule = stocksModule;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStockExchange(AddStockExchangeRequest request)
        {
            await _stocksModule.ExecuteCommandAsync(
                new AddNewStockExchangeCommand(
                    request.Name,
                    request.ExchangeCode));

            return Ok();
        }
    }
}