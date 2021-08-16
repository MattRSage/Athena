using Athena.Stocks.Application.Contracts;
using MediatR;

namespace Athena.Stocks.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}