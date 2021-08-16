using System.Threading.Tasks;
using Athena.Stocks.Application.Contracts;
using Athena.Stocks.Application.Stocks.AddNewStock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athena.API.Modules.Stocks.Stocks
{
    [Route("api/stocks/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStocksModule _stocksModule;

        public StocksController(IStocksModule stocksModule)
        {
            _stocksModule = stocksModule;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStock([FromBody] AddStockRequest request)
        {
            await _stocksModule.ExecuteCommandAsync(
                new AddNewStockCommand(
                    request.StockExchangeId,
                    request.Symbol));

            return Ok();
        }
    }
}