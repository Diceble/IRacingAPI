using IRacingAPI.Models.Enumerations;
using IRacingAPI.Models.EventArguments;

namespace IRacingAPI;
internal class IRacingEventHandler
{
    public EventRaiseTypes EventRaiseType { get; set; }

    /// <summary>
    /// Event raised when the sim outputs telemetry information (60 times per second).
    /// </summary>
    public event EventHandler<TelemetryUpdatedEventArgs> TelemetryUpdated;

    /// <summary>
    /// Event raised when the sim refreshes the session info (few times per minute).
    /// </summary>
    public event EventHandler<SessionInfoUpdatedEventArgs> SessionInfoUpdated;

    /// <summary>
    /// Event raised when the SDK detects the sim for the first time.
    /// </summary>
    public event EventHandler Connected;

    /// <summary>
    /// Event raised when the SDK no longer detects the sim (sim closed).
    /// </summary>
    public event EventHandler Disconnected;


    private readonly SynchronizationContext _context;

    public IRacingEventHandler()
    {
        _context = SynchronizationContext.Current ?? new();
    }
    internal void RaiseEvent<T>(Action<T> del, T e)
    where T : EventArgs
    {
        SendOrPostCallback callback = new(obj =>
        {
            if (obj is T eventArg)
            {
                del(eventArg);
            }
        });

        if (_context != null && _context == SynchronizationContext.Current && EventRaiseType == EventRaiseTypes.CurrentThread)
        {
            // Post the event method on the thread context, this raises the event on the thread on which the SdkWrapper object was created
            _context.Post(callback, e);
        }
        else
        {
            // Simply invoke the method, this raises the event on the background thread that the SdkWrapper created
            // Care must be taken by the user to avoid cross-thread operations
            callback.Invoke(e);
        }
    }
}
