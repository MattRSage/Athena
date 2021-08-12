namespace Athena.BuildingBlocks.Outbox
{
    public enum OutboxStateEnum
    {
        Unprocessed = 0,
        InProgress = 1,
        Processed = 2,
        ProcessingFailed = 3
    }
}