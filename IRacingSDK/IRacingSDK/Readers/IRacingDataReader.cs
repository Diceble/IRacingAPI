﻿using IRacingAPI;
using IRacingAPI.Exceptions;
using IRacingAPI.Models;
using IRacingAPI.Models.Enumerations;
using System.IO.MemoryMappedFiles;

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
    /// Fetches the data from the memory mapped file based on the variable header
    /// </summary>
    /// <param name="variableHeader">Variable header that gets used to find the data</param>
    /// <param name="fileMapViewAccessor">Memmory mapped file that contains all the data</param>
    /// <param name="buffer">piece of memory where data lives</param>
    /// <returns></returns>
    /// <exception cref="VariableTypeNotfFoundException"></exception>
    internal static object FetchData(TelemetryVariableHeader variableHeader, MemoryMappedViewAccessor fileMapViewAccessor, int buffer)
    {
        var variableOffset = variableHeader.Offset;
        var count = variableHeader.Count;

        return variableHeader.TypeOfVariable switch
        {
            VariableType.irChar => ReadStringValues(fileMapViewAccessor, count, buffer, variableOffset),
            VariableType.irBool => ReadBoolValues(fileMapViewAccessor, count, buffer, variableOffset),
            VariableType.irInt or VariableType.irBitField => ReadIntValues(fileMapViewAccessor, count, buffer, variableOffset),
            VariableType.irFloat => ReadFloatValues(fileMapViewAccessor, count, buffer, variableOffset),
            VariableType.irDouble => ReadDoubleValues(fileMapViewAccessor, buffer, variableOffset, count),
            _ => throw new VariableTypeNotfFoundException(),
        };
    }

    /// <summary>
    /// Fetches the variable headers from the memory mapped file
    /// </summary>
    /// <param name="fileMapView">Memmory mapped file that contains all the data</param>
    /// <param name="iRSDKHeader"></param>
    /// <param name="variableHeaderSize"></param>
    /// <returns> <see cref="Dictionary{string, TelemetryVariableHeader}"/> that contains all the variable headers that are available in the current session</returns>
    internal static Dictionary<string, TelemetryVariableHeader> GetVariableHeaders(MemoryMappedViewAccessor fileMapView, IRSDKHeader iRSDKHeader, int variableHeaderSize)
    {

        Dictionary<string, TelemetryVariableHeader> variableHeaders = [];
        for (var i = 0; i < iRSDKHeader.AmountOfVariables; i++)
        {
            var type = (int)ReadIntValues(fileMapView, buffer: i * variableHeaderSize, variableOffset: iRSDKHeader.VarHeaderOffset);
            var offset = (int)ReadIntValues(fileMapView, buffer: i * variableHeaderSize + _variableOffsetOffset, variableOffset: iRSDKHeader.VarHeaderOffset);
            var count = (int)ReadIntValues(fileMapView, buffer: i * variableHeaderSize + _variableCountOffset, variableOffset: iRSDKHeader.VarHeaderOffset);

            var nameStr = ReadStringValues(fileMapView, Definitions.MaxString, buffer: i * variableHeaderSize + _variableNameOffset, variableOffset: iRSDKHeader.VarHeaderOffset);
            var descStr = ReadStringValues(fileMapView, Definitions.MaxDesc, buffer: i * variableHeaderSize + _variableDescriptionOffset, variableOffset: iRSDKHeader.VarHeaderOffset);
            var unitStr = ReadStringValues(fileMapView, Definitions.MaxString, buffer: i * variableHeaderSize + _variableUnitOffset, variableOffset: iRSDKHeader.VarHeaderOffset);

            variableHeaders[nameStr] = new TelemetryVariableHeader((VariableType)type, offset, count, nameStr, descStr, unitStr);
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
        return ReadStringValues(fileMapView, header.SessionInfoLength, variableOffset: header.SessionInfoOffset);
    }

    private static object ReadIntValues(MemoryMappedViewAccessor fileMapViewAccessor, int count = 0, int buffer = 0, int variableOffset = 0)
    {
        if (count > 1)
        {
            var data = new int[count];
            fileMapViewAccessor.ReadArray(buffer + variableOffset, data, 0, count);
            return data;
        }
        else
        {
            return fileMapViewAccessor.ReadInt32(buffer + variableOffset);
        }
    }

    private static string ReadStringValues(MemoryMappedViewAccessor fileMapViewAccessor, int count, int buffer = 0, int variableOffset = 0)
    {
        var data = new byte[count];
        fileMapViewAccessor.ReadArray(buffer + variableOffset, data, 0, count);
        return System.Text.Encoding.Default.GetString(data).TrimEnd(['\0']);
    }

    private static object ReadDoubleValues(MemoryMappedViewAccessor fileMapViewAccessor, int buffer, int variableOffset, int count)
    {
        if (count > 1)
        {
            var data = new double[count];
            fileMapViewAccessor.ReadArray(buffer + variableOffset, data, 0, count);
            return data;
        }
        else
        {
            return fileMapViewAccessor.ReadDouble(buffer + variableOffset);
        }
    }

    private static object ReadFloatValues(MemoryMappedViewAccessor fileMapViewAccessor, int count, int buffer = 0, int variableOffset = 0)
    {
        if (count > 1)
        {
            var data = new float[count];
            fileMapViewAccessor.ReadArray(buffer + variableOffset, data, 0, count);
            return data;
        }
        else
        {
            return fileMapViewAccessor.ReadSingle(buffer + variableOffset);
        }
    }
    private static object ReadBoolValues(MemoryMappedViewAccessor fileMapViewAccessor, int count, int buffer = 0, int variableOffset = 0)
    {
        if (count > 1)
        {
            var data = new bool[count];
            fileMapViewAccessor.ReadArray(buffer + variableOffset, data, 0, count);
            return data;
        }
        else
        {
            return fileMapViewAccessor.ReadBoolean(buffer + variableOffset);
        }
    }
}
