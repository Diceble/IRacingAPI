using IRacingAPI.Models.DataModels.YAML;

namespace IRacingAPI.Models.EventArguments;
public class SessionInfoUpdatedEventArgs(SessionData sessionData, double time) : APIUpdateEventArgs(time)
{
    private readonly SessionData _sessionData = sessionData;

    /// <summary>
    /// Gets the session info.
    /// </summary>
    public SessionData SessionInfo => _sessionData;
}
