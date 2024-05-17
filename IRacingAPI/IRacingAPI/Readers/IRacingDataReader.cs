using IRacingAPI.Models;
using IRacingAPI.Models.DataModels.TelemetryData;
using IRacingAPI.Models.Enumerations;
using System.IO.MemoryMappedFiles;
using YamlDotNet.Core.Tokens;

namespace IRacingAPI.Readers;

/// <summary>
/// Class that contains the methods to get the data from the game
/// </summary>
internal class IRacingDataReader
{
    private const int _variableOffsetOffset = 4;
    private const int _variableCountOffset = 8;
    private const int _variableNameOffset = 16;
    private const int _variableDescriptionOffset = 48;
    private const int _variableUnitOffset = 112;

    /// <summary>
    /// Reads values from the memory mapped file based on the type of the variable which must be a struct
    /// </summary>
    /// <typeparam name="T">Type that you want to extract which must be a struct</typeparam>
    /// <param name="fileMapViewAccessor">Memmory mapped file that contains all the data</param>
    /// <param name="header"> variableHeader that contains infromation to get the values and setup up <see cref="TelemetryValue{T}"/></param>
    /// <param name="buffer">Indicates along withvariableOffset where reading should start</param>
    /// <returns><see cref="TelemetryValue{T}"/> which contains the values of the variable </returns>
    internal static TelemetryValue<T[]> ReadTelemetryValues<T>(MemoryMappedViewAccessor fileMapViewAccessor, VariableHeader header, int buffer = 0) where T : struct
    {
        TelemetryValue<T[]> telemetryValue = new()
        {
            Name = header.Name,
            Description = header.Desc,
            Unit = header.Unit,
            Type = header.TypeOfVariable,
            Value = ReadValues<T>(fileMapViewAccessor, header.Count, buffer, header.Offset)
        };

        return telemetryValue;
    }

    /// <summary>
    /// Reads value from the memory mapped file based on the type of the variable which must be a struct
    /// </summary>
    /// <typeparam name="T">Type that you want to extract which must be a struct</typeparam>
    /// <param name="fileMapViewAccessor">Memmory mapped file that contains all the data</param>
    /// <param name="header"> variableHeader that contains infromation to get the values and setup up <see cref="TelemetryValue{T}"/></param>
    /// <param name="buffer">Indicates along withvariableOffset where reading should start</param>
    /// <returns><see cref="TelemetryValue{T}"/> which contains the value of the variable </returns>
    internal static TelemetryValue<T> ReadTelemetryValue<T>(MemoryMappedViewAccessor fileMapViewAccessor, VariableHeader header, int buffer = 0) where T : struct
    {
        TelemetryValue<T> telemetryValue = new()
        {
            Name = header.Name,
            Description = header.Desc,
            Unit = header.Unit,
            Type = header.TypeOfVariable,
            Value = ReadValue<T>(fileMapViewAccessor, buffer, header.Offset)
        };

        return telemetryValue;
    }

    /// <summary>
    /// Gets values from the memory mapped file based on the type of the variable which must be a struct
    /// </summary>
    /// <typeparam name="T">Type that you want to extract which must be a struct</typeparam>
    /// <param name="fileMapViewAccessor">Memmory mapped file that contains all the data</param>
    /// <param name="count">amount of data that should get fetched</param>
    /// <param name="buffer">Indicates along withvariableOffset where reading should start</param>
    /// <param name="variableOffset">Indicates along with buffer where reading should start</param>
    /// <returns>the values of the specified variable header</returns>
    internal static T[] ReadValues<T>(MemoryMappedViewAccessor fileMapViewAccessor, int count = 0, int buffer = 0, int variableOffset = 0) where T : struct
    {
        T[] data = new T[count];
        fileMapViewAccessor.ReadArray(buffer + variableOffset, data, 0, count);
        return data;
    }

    /// <summary>
    /// Reads value from the memory mapped file based on the type of the variable which must be a struct
    /// </summary>
    /// <typeparam name="T">Type that you want to extract which must be a struct</typeparam>
    /// <param name="fileMapViewAccessor">Memmory mapped file that contains all the data</param>
    /// <param name="buffer">Indicates along with variableOffset where reading should start</param>
    /// <param name="variableOffset">Indicates along with buffer where reading should start</param>
    /// <returns>the value of the specified variable header</returns>
    internal static T ReadValue<T>(MemoryMappedViewAccessor fileMapViewAccessor, int buffer = 0, int variableOffset = 0) where T : struct
    {
        fileMapViewAccessor.Read(buffer + variableOffset, out T structure);
        return structure;
    }

    /// <summary>
    /// Fetches the variable headers from the memory mapped file
    /// </summary>
    /// <param name="fileMapView">Memmory mapped file that contains all the data</param>
    /// <param name="iRSDKHeader"></param>
    /// <param name="variableHeaderSize"></param>
    /// <returns> <see cref="Dictionary{string, TelemetryVariableHeader}"/> that contains all the variable headers that are available in the current session</returns>
    internal static Dictionary<string, VariableHeader> GetVariableHeaders(MemoryMappedViewAccessor fileMapView, IRSDKHeader iRSDKHeader, int variableHeaderSize)
    {
        Dictionary<string, VariableHeader> variableHeaders = [];
        for (var i = 0; i < iRSDKHeader.AmountOfVariables; i++)
        {
            var type = ReadValue<int>(fileMapView, buffer: i * variableHeaderSize, variableOffset: iRSDKHeader.VarHeaderOffset);
            var offset = ReadValue<int>(fileMapView, buffer: i * variableHeaderSize + _variableOffsetOffset, variableOffset: iRSDKHeader.VarHeaderOffset);
            var count = ReadValue<int>(fileMapView, buffer: i * variableHeaderSize + _variableCountOffset, variableOffset: iRSDKHeader.VarHeaderOffset);

            var name = ReadStringValues(fileMapView, Definitions.MaxString, buffer: i * variableHeaderSize + _variableNameOffset, variableOffset: iRSDKHeader.VarHeaderOffset);
            var description = ReadStringValues(fileMapView, Definitions.MaxDesc, buffer: i * variableHeaderSize + _variableDescriptionOffset, variableOffset: iRSDKHeader.VarHeaderOffset);
            var unit = ReadStringValues(fileMapView, Definitions.MaxString, buffer: i * variableHeaderSize + _variableUnitOffset, variableOffset: iRSDKHeader.VarHeaderOffset);

            variableHeaders[name] = new VariableHeader((VariableType)type, offset, count, name, description, unit);
        }
        return variableHeaders;
    }

    /// <summary>
    /// Gets the session data from the memory mapped file 
    /// </summary>
    /// <param name="fileMapView">Memmory mapped file that contains all the data</param>
    /// <param name="header"></param>
    /// <returns>Session data as a string in YAML formatation</returns>
    internal static string GetSessionData(MemoryMappedViewAccessor fileMapView, IRSDKHeader header)
    {
        var data = ReadValues<byte>(fileMapView, header.SessionInfoLength, variableOffset: header.SessionInfoOffset);
        return System.Text.Encoding.Default.GetString(data).TrimEnd(['\0']);
    }

    private static string ReadStringValues(MemoryMappedViewAccessor fileMapViewAccessor, int count, int buffer = 0, int variableOffset = 0)
    {
        var data = ReadValues<byte>(fileMapViewAccessor, count, buffer, variableOffset);
        return System.Text.Encoding.Default.GetString(data).TrimEnd(['\0']);
    }
}
