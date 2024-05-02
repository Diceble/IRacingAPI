using IRacingAPI.Models.DataModels.YAML;

namespace IRacingAPI.Models.EventArguments;
internal class SessionInfoUpdatedEventArgs : SdkUpdateEventArgs
{
    public SessionInfoUpdatedEventArgs(string sessionInfo, double time) : base(time)
    {
        _SessionInfo = new SessionData();
    }

    private readonly SessionData _SessionInfo;
    /// <summary>
    /// Gets the session info.
    /// </summary>
    public SessionData SessionInfo => _SessionInfo;
}
