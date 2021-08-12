using System.Threading.Tasks;

namespace Athena.BuildingBlocks.Outbox
{
    public interface IOutboxWriter
    {
        Task Add(OutboxMessage message);
    }
}