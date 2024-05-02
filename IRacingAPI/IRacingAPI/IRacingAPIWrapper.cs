using IRacingAPI.Abstractions;
using IRacingAPI.Models.DataModels.YAML;
using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization;

namespace IRacingAPI;
public class IRacingAPIWrapper : IIRacingSDKWrapper
{
    private bool _isRunning;
    private Task? _looper;
    private IIRacingDataApi _sdk;
    private bool _isConnected;
    private bool _hasConnected;
    private int _driverId = -1;
    private int waitTime;
    private readonly int _connectSleepTime;

    private readonly ILogger<IRacingAPIWrapper> _logger;

    public IRacingAPIWrapper(ILogger<IRacingAPIWrapper> logger, IIRacingDataApi sdk)
    {
        _driverId = -1;
        _connectSleepTime = 1000;
        _logger = logger;
        _sdk = sdk;
    }

    /// <summary>
    /// Connects to iRacing and starts the main loop in a background thread
    /// </summary>
    public void Start()
    {
        _logger.LogInformation("Starting iRacing SDK Wrapper");
        _isRunning = true;
        _looper?.Dispose();
        _looper = Task.Run(Loop);
        _logger.LogInformation("Successfully started loop");
    }

    private void Loop()
    {
        _logger.LogInformation("Starting iRacing SDK Wrapper loop");
        var lastUpdate = -1;

        while (_isRunning)
        {
            //Check if we can find the game
            if (_sdk.IsConnected())
            {
                if (!_isConnected)
                {

                }
                _hasConnected = true;
                _isConnected = true;

                var attempts = 0;
                const int maxAttempts = 99;

                var SessionNumber = TryGetSessionNum();
                while (SessionNumber == null && attempts <= maxAttempts)
                {
                    attempts++;
                    SessionNumber = TryGetSessionNum();
                }

                if (attempts >= maxAttempts)
                {
                    _logger.LogWarning("Too many attempts fetching session number");
                    continue;
                }

                // Parse out your own driver Id
                if (_driverId == -1)
                {
                    _driverId = (int)_sdk.GetData("PlayerCarIdx");
                }

                // Get the session time (in seconds) of this update
                var time = (double)_sdk.GetData("SessionTime");

                var newUpdate = _sdk.GetIRSDKHeader().SessionInfoUpdate;
                if (newUpdate != lastUpdate)
                {
                    // Get the session info
                    var sessionInfo = _sdk.GetSessionData();

                    IDeserializer deserializer = new DeserializerBuilder()
                        .IgnoreUnmatchedProperties()
                        .Build();

                    SessionData? sessionData = deserializer.Deserialize<SessionData>(sessionInfo);


                    //this.RaiseEvent(OnSessionInfoUpdated, new SessionInfoUpdatedEventArgs(sessionInfo, time));
                    lastUpdate = newUpdate;
                }
            }
            else if (_hasConnected)
            {
                _logger.LogInformation("Lost connection to iRacing");
                // We have already been initialized before, so the sim is closing
                //this.RaiseEvent(OnDisconnected, EventArgs.Empty);

                _sdk.ShutDown();
                _driverId = -1;
                lastUpdate = -1;
                _isConnected = false;
                _hasConnected = false;
            }
            else
            {
                _logger.LogInformation("Trying to connect to iRacing");
                _isConnected = false;
                _hasConnected = false;
                _driverId = -1;
                _sdk.StartUp();
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
            var sessionnum = _sdk.GetData("SessionNum");
            return sessionnum;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
}
