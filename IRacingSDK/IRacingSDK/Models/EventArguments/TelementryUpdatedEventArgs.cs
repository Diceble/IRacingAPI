namespace IRacingAPI.Models.EventArguments;

internal class TelemetryUpdatedEventArgs : SdkUpdateEventArgs
{
    //public TelemetryUpdatedEventArgs(TelemetryInfo info, double time) : base(time)
    //{
    //    _TelemetryInfo = info;
    //}

    //private readonly TelemetryInfo _TelemetryInfo;
    ///// <summary>
    ///// Gets the telemetry info object.
    ///// </summary>
    //public TelemetryInfo TelemetryInfo { get { return _TelemetryInfo; } }
    public TelemetryUpdatedEventArgs(double time) : base(time)
    {
    }
}