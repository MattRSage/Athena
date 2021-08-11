using MediatR;

namespace Athena.BuildingBlocks.Application
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
