namespace IRacingAPI.Models.EventArguments;

internal class SdkUpdateEventArgs : EventArgs
{
    public SdkUpdateEventArgs(double time)
    {
        _UpdateTime = time;
    }

    private readonly double _UpdateTime;
    /// <summary>
    /// Gets the time (in seconds) when this update occured.
    /// </summary>
    public double UpdateTime => _UpdateTime;
}
