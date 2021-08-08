using System.Threading.Tasks;

namespace Athena.Stocks.Domain.Services
{
    public interface IStockLookup
    {
        Task<string> GetStockName(string symbol);
    }
}