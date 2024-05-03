namespace IRacingAPI.Abstractions;

public interface IIRacingSDKWrapper
{
    void Start(CancellationToken ct);
    void Stop();
}