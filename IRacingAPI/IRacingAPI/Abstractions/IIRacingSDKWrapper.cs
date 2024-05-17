using IRacingAPI.Models.EventArguments;

namespace IRacingAPI.Abstractions;

public interface IIRacingSDKWrapper
{
    event EventHandler<TelemetryUpdatedEventArgs> TelemetryUpdated;
    event EventHandler<SessionInfoUpdatedEventArgs> SessionInfoUpdated;
    event EventHandler Connected;
    event EventHandler Disconnected;

    void Start(CancellationToken ct);
    void Stop();
}