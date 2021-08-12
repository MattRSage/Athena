using System.Threading;
using System.Threading.Tasks;

namespace Athena.BuildingBlocks.Outbox
{
    public interface IOutboxProcessDispatcher
    {
        Task DispatchProcessOutboxMessages(TransactionCompleted request, CancellationToken cancellationToken = default);
    }
}