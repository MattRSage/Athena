namespace Athena.BuildingBlocks.Outbox
{
    public interface IOutboxMapper<T>
        where T : class
    {
        T Deserialize(OutboxMessage message);
    }
}