using IRacingAPI.Abstractions;
using IRacingAPI.Exceptions;
using IRacingAPI.Models;
using IRacingAPI.Models.DataModels.TelemetryData;
using IRacingAPI.Models.Enumerations;
using IRacingAPI.Readers;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.SafeHandles;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace IRacingAPI;

/// <summary>
/// Class that contains the methods to interact with iRacing to get the data from the game
/// </summary>
public class IRacingApi(ILogger<IRacingApi> logger) : IIRacingApi
{
    private readonly ILogger<IRacingApi> _logger = logger;

    public int VariableHeaderSize = 144;

    /// <summary>
    /// Contains the information needed to find and read session information and telemetry.
    /// Can be used as a kind of look-up-table to find specific telemetry variables withing the telemetry buffer.
    /// </summary>
    public Dictionary<string, VariableHeader> variableHeaders = [];

    private IRSDKHeader? header;
    private MemoryMappedFile? iRacingFile;
    private MemoryMappedViewAccessor? fileMapViewAccessor;

    public bool IsInitialized = false;

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
            if (startUpEvent == nint.Zero)
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
            _logger.LogError(ex, ex.Message);
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
        return IsInitialized && header != null && fileMapViewAccessor != null
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


    public T[] ReadValueByVariableHeaderName<T>(string name) where T : struct
    {
        return IsConnected() ? TryReadValueByVariableHeaderName<T>(name) : throw new IRacingSDKNotInitializedException();
    }

    public IRSDKHeader? GetIRSDKHeader()
    {
        return header;
    }

    public TelemetryInfo GetTelemetryInfo()
    {
        List<string> unknownHeaders = new();
        TelemetryInfo telemetryInfo = new();

        foreach (KeyValuePair<string, VariableHeader> keyValuePair in variableHeaders)
        {
            VariableHeader variableHeader = keyValuePair.Value;

            if (typeof(TelemetryInfo).GetProperty(variableHeader.Name) != null)
            {
                object value = GetTelemetryValue(keyValuePair);

                try
                {
                    telemetryInfo.GetType().GetProperty(variableHeader.Name)?.SetValue(telemetryInfo, value);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
            else
            {
                unknownHeaders.Add(variableHeader.Name);
            }
        }
        return telemetryInfo;
    }

    private T[] TryReadValueByVariableHeaderName<T>(string name) where T : struct
    {
        if (variableHeaders.TryGetValue(name, out VariableHeader? variableHeader))
        {
            if (variableHeader.Count > 1)
            {
                return IRacingDataReader.ReadValues<T>(fileMapViewAccessor!, variableHeader.Count, header!.Buffer, variableHeader.Offset);
            }
            else
            {
                T value = IRacingDataReader.ReadValue<T>(fileMapViewAccessor!, header!.Buffer, variableHeader.Offset);
                return [value];
            }
        }
        else
        {
            throw new VariableHeaderNotFoundException(name);
        }
    }

    private object GetTelemetryValue(KeyValuePair<string, VariableHeader> keyValuePair)
    {
        VariableHeader variableHeader = keyValuePair.Value;
        object value = keyValuePair.Value.Count > 1
            ? variableHeader.TypeOfVariable switch
            {
                VariableType.irChar => IRacingDataReader.ReadTelemetryValues<char>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irBool => IRacingDataReader.ReadTelemetryValues<bool>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irInt or VariableType.irBitField => IRacingDataReader.ReadTelemetryValues<int>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irFloat => IRacingDataReader.ReadTelemetryValues<float>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irDouble => IRacingDataReader.ReadTelemetryValues<double>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                _ => throw new ArgumentException("Invalid VariableType"),
            }
            : (variableHeader.TypeOfVariable switch
            {
                VariableType.irChar => IRacingDataReader.ReadTelemetryValue<char>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irBool => IRacingDataReader.ReadTelemetryValue<bool>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irInt or VariableType.irBitField => IRacingDataReader.ReadTelemetryValue<int>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irFloat => IRacingDataReader.ReadTelemetryValue<float>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                VariableType.irDouble => IRacingDataReader.ReadTelemetryValue<double>(fileMapViewAccessor!, variableHeader, header!.Buffer),
                _ => throw new ArgumentException("Invalid VariableType"),
            });
        return value;
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