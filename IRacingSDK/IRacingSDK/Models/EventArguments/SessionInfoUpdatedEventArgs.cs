using IRacingSDK.Models.EventArguemnts;

namespace IRacingSDK.Models.EventArguments;
internal class SessionInfoUpdatedEventArgs : SdkUpdateEventArgs
{
    public SessionInfoUpdatedEventArgs(string sessionInfo, double time) : base(time)
    {
        _SessionInfo = new SessionInfo();
    }

    private readonly SessionInfo _SessionInfo;
    /// <summary>
    /// Gets the session info.
    /// </summary>
    public SessionInfo SessionInfo { get { return _SessionInfo; } }
}
