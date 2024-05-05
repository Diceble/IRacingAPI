using IRacingAPI.Models.DataModels.TelemetryData;

namespace IRacingAPI.Models.EventArguments;

public class TelemetryUpdatedEventArgs(TelemetryInfo info, double time) : APIUpdateEventArgs(time)
{
    private readonly TelemetryInfo _TelemetryInfo = info;

    /// <summary>
    /// Gets the telemetry info object.
    /// </summary>
    public TelemetryInfo TelemetryInfo => _TelemetryInfo;
}