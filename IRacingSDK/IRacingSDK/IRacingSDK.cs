using IRacingSDK.Abstractions;
using IRacingSDK.Exceptions;
using IRacingSDK.Models;
using IRacingSDK.Readers;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.SafeHandles;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace IRacingSDK;

/// <summary>
/// Class that contains the methods to interact with iRacing to get the data from the game
/// </summary>
public class IRacingSDK : IIRacingSDK
{
    private readonly ILogger<IRacingSDK> _logger;

    public int VariableHeaderSize = 144;

    /// <summary>
    /// Contains the information needed to find and read session information and telemetry.
    /// Can be used as a kind of look-up-table to find specific telemetry variables withing the telemetry buffer.
    /// </summary>
    public Dictionary<string, TelemetryVariableHeader> variableHeaders = [];

    private IRSDKHeader header;

    private MemoryMappedFile iRacingFile;
    private MemoryMappedViewAccessor fileMapViewAccessor;

    public bool IsInitialized = false;

    public IRacingSDK(ILogger<IRacingSDK> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Starts the SDK and connects to all the necessary resources to start reading the data from the game
    /// </summary>
    /// <returns cref="bool">True/False based on whether the startup was executed successfully </returns>
    /// <exception cref="InvalidOSPlatformException"> When operating system is not supported</exception>
    public bool StartUp()
    {
        if (IsInitialized)
        {
            return true;
        }

        try
        {
            fileMapViewAccessor = AccessIRacingFile();

            //Gets the size of the variable header
            VariableHeaderSize = Marshal.SizeOf(typeof(VarHeader));

            var startUpEvent = DLLInjector.OpenEvent(Definitions.DesiredAccess, false, Definitions.DataValidEventName);
            if (startUpEvent == IntPtr.Zero)
            {               
                throw new Exception("Could not open event");
            }
            else
            {
                AutoResetEvent autorResetEvent = new(false)
                {
                    SafeWaitHandle = new SafeWaitHandle(startUpEvent, false)
                };

                if (!autorResetEvent.WaitOne(0))
                {
                    header = GetIRSDKHeader(fileMapViewAccessor);
                    variableHeaders.Clear();
                    variableHeaders = IRacingDataReader.GetVariableHeaders(fileMapViewAccessor, header, VariableHeaderSize);
                    IsInitialized = true;
                }
                autorResetEvent.Close();
                DLLInjector.CloseHandle(startUpEvent);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Gets the session data from the game
    /// </summary>
    /// <returns></returns>
    /// <exception cref="IRacingSDKNotInitializedException"></exception>
    public string GetSessionData()
    {
        return IsInitialized && header != null
            ? IRacingDataReader.GetSessionData(fileMapViewAccessor, header)
            : throw new IRacingSDKNotInitializedException();
    }

    /// <summary>
    /// Disposes the memory mapped file and the view accessor
    /// </summary>
    public void ShutDown()
    {
        IsInitialized = false;
        header = null;
        fileMapViewAccessor?.Dispose();
        iRacingFile?.Dispose();

    }

    /// <summary>
    /// Indicates if the SDK is connected to the game by checking the status in the header
    /// </summary>
    /// <returns></returns>
    public bool IsConnected()
    {
        return IsInitialized && header != null && (header.Status & 1) > 0;
    }

    /// <summary>
    /// Gets the data from the game based on the name of the variable
    /// </summary>
    /// <param name="name">name of the variable that the data gets collected from</param>
    /// <returns>value from provided <see cref="name"/></returns>
    /// <exception cref="VariableHeaderNotFoundException">Meaning provided Variable name does not exist</exception>
    /// <exception cref="IRacingSDKNotInitializedException"></exception>
    public object GetData(string name)
    {
        return IsInitialized && header != null ? TryGetData(name) : throw new IRacingSDKNotInitializedException();
    }

    public IRSDKHeader GetIRSDKHeader()
    {
        return header;
    }

    private object TryGetData(string name)
    {
        return variableHeaders.TryGetValue(name, out TelemetryVariableHeader? value)
                ? IRacingDataReader.FetchData(value, fileMapViewAccessor, header.Buffer)
                : throw new VariableHeaderNotFoundException(name);
    }

    private MemoryMappedViewAccessor AccessIRacingFile()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            //Open the memory mapped file to read the data from the game, windows check is already done in the StartUp method
            iRacingFile = MemoryMappedFile.OpenExisting(Definitions.MemMapFileName);
        }
        else
        {
            throw new InvalidOSPlatformException(RuntimeInformation.OSDescription);
        }
        //Create a view accessor to read the data from the memory mapped file and return it
        return iRacingFile.CreateViewAccessor();
    }

    private static IRSDKHeader GetIRSDKHeader(MemoryMappedViewAccessor fileMapView)
    {
        return new IRSDKHeader(fileMapView);
    }
}