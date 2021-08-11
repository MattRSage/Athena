using MediatR;

namespace Athena.BuildingBlocks.Application
{
    public interface ICommand
    {
    }

    public interface ICommand<T> : IRequest<T>, ICommand
    {
    }

}
