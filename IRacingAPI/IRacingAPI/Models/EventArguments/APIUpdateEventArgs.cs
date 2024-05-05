namespace IRacingAPI.Models.EventArguments;

public class APIUpdateEventArgs : EventArgs
{
    public APIUpdateEventArgs(double time)
    {
        _UpdateTime = time;
    }

    private readonly double _UpdateTime;
    /// <summary>
    /// Gets the time (in seconds) when this update occured.
    /// </summary>
    public double UpdateTime => _UpdateTime;
}
