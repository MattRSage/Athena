namespace Athena.BuildingBlocks.Telemetry
{
    public interface ITelemetryService
    {
        void StartDependentOperation(string description, string parentOperationId);
        void StopOperation();
    }
}