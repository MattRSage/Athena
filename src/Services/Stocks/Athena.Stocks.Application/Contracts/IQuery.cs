using MediatR;

namespace Athena.Stocks.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}