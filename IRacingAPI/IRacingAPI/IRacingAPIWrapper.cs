using IRacingAPI.Abstractions;
using IRacingAPI.Models.DataModels.TelemetryData;
using IRacingAPI.Models.DataModels.YAML;
using IRacingAPI.Models.EventArguments;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;

namespace IRacingAPI;
public class IRacingAPIWrapper : IIRacingSDKWrapper
{

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

    private bool _isRunning;
    private Task? _looper;
    private IIRacingApi _api;
    private bool _isConnected;
    private bool _hasConnected;
    private int waitTime;
    private readonly int _connectSleepTime;
    private readonly IRacingEventRaiser _eventRaiser;

    private readonly ILogger<IRacingAPIWrapper> _logger;

    public IRacingAPIWrapper(ILogger<IRacingAPIWrapper> logger, IIRacingApi sdk)
    {
        _connectSleepTime = 1000;
        _logger = logger;
        _api = sdk;
        _eventRaiser = new IRacingEventRaiser();
    }

    /// <summary>
    /// Connects to iRacing and starts the main loop in a background thread
    /// </summary>
    public void Start(CancellationToken ct)
    {
        _logger.LogDebug("Starting iRacing SDK Wrapper");
        _isRunning = true;
        _looper?.Dispose();
        _looper = Task.Run(Loop, ct);
        _logger.LogDebug("Successfully started loop");
    }

    private void Loop()
    {
        _logger.LogDebug("Starting iRacing SDK Wrapper loop");
        var lastUpdate = -1;

        while (_isRunning)
        {
            //Check if we can find the game
            if (_api.IsConnected())
            {
                if (!_isConnected)
                {
                    _eventRaiser.RaiseEvent(OnConnected, EventArgs.Empty);
                }
                _hasConnected = true;
                _isConnected = true;

                // Get the session time (in seconds) of this update
                var time = _api.ReadValueByVariableHeaderName<double>("SessionTime").First();

                TelemetryInfo telemetryInfo = _api.GetTelemetryInfo();
                _eventRaiser.RaiseEvent(OnTelemetryUpdated, new TelemetryUpdatedEventArgs(telemetryInfo, time));
                _logger.LogDebug("Fetched Telemetry info");

                var newUpdate = _api.GetIRSDKHeader()?.SessionInfoUpdate;
                if (newUpdate != lastUpdate)
                {
                    // Get the session info
                    var yamlSessionInfo = _api.GetSessionData();

                    IDeserializer deserializer = new DeserializerBuilder()
                        .IgnoreUnmatchedProperties()
                        .Build();

                    SessionData? sessionData = deserializer.Deserialize<SessionData>(yamlSessionInfo);
                    _eventRaiser.RaiseEvent(OnSessionInfoUpdated, new SessionInfoUpdatedEventArgs(sessionData, time));
                    _logger.LogDebug("Fetched Session Data");
                    lastUpdate = newUpdate ?? -1;
                }
            }
            else if (_hasConnected)
            {
                _logger.LogDebug("Lost connection to iRacing");
                // We have already been initialized before, so the sim is closing
                _eventRaiser.RaiseEvent(OnDisconnected, EventArgs.Empty);

                _api.ShutDown();
                lastUpdate = -1;
                _isConnected = false;
                _hasConnected = false;
            }
            else
            {
                _logger.LogDebug("Trying to connect to iRacing");
                _isConnected = false;
                _hasConnected = false;
                _api.StartUp();
            }

            // Sleep for a short amount of time until the next update is available
            if (_isConnected)
            {
                if (waitTime is <= 0 or > 1000)
                {
                    waitTime = 15;
                }

                Thread.Sleep(waitTime);
            }
            else
            {
                // Not connected yet, no need to check every 16 ms, let's try again in some time
                Thread.Sleep(_connectSleepTime);
            }
        }
    }

    /// <summary>
    /// Stops the main loop
    /// </summary>
    public void Stop()
    {
        _isRunning = false;
        _looper?.Dispose();
    }

    private object TryGetSessionNum()
    {
        try
        {
            var sessionnum = _api.ReadValueByVariableHeaderName<int>("SessionNum").First();
            return sessionnum;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    private void OnSessionInfoUpdated(SessionInfoUpdatedEventArgs e)
    {
        this.SessionInfoUpdated?.Invoke(this, e);
    }

    private void OnTelemetryUpdated(TelemetryUpdatedEventArgs e)
    {

        this.TelemetryUpdated?.Invoke(this, e);
    }

    private void OnConnected(EventArgs e)
    {
        this.Connected?.Invoke(this, e);
    }

    private void OnDisconnected(EventArgs e)
    {
        this.Disconnected?.Invoke(this, e);
    }
}
