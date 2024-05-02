namespace IRacingSDK.Models.Enumerations;

/// <summary>
/// The way in which events of the SDK wrapper are raised.
/// </summary>
public enum EventRaiseTypes
{
    /// <summary>
    /// Events are raised on the current thread (the thread on which the SdkWrapper object was created).
    /// </summary>
    CurrentThread,

    /// <summary>
    /// Events are raised on a separate background thread (synchronization / invokation required to update UI).
    /// </summary>
    BackgroundThread
}
