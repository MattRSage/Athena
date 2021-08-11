using System.Threading;
using System.Threading.Tasks;

namespace Athena.BuildingBlocks.Application.DomainEventsDispatching
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEvents(CancellationToken cancellationToken);
    }
}
