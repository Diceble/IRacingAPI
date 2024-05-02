using System.IO.MemoryMappedFiles;

namespace IRacingAPI.Models;
public class IRSDKHeader
{
    //Header offsets

    /// <summary>
    /// Offset of version in header
    /// </summary>
    public const int VersionOffset = 0;

    /// <summary>
    /// Offset of status in header
    /// </summary>
    public const int StatusOffset = 4;

    /// <summary>
    /// Offset of tick rate in header
    /// </summary>
    public const int TickRateOffset = 8;

    /// <summary>
    /// Offset of session info update in header
    /// </summary>
    public const int SessionInfoUpdateOffset = 12;

    /// <summary>
    /// Offset of session info length in header
    /// </summary>
    public const int SessionInfoLenngthOffset = 16;

    /// <summary>
    /// Offset of session info offset in header
    /// </summary>
    public const int SessionInfoOffsetOffset = 20;

    /// <summary>
    /// Offset of number of variables in header
    /// </summary>
    public const int NumberOfVariablesOffset = 24;

    /// <summary>
    /// Offset of variable header offset in header
    /// </summary>
    public const int VariableHeaderOffsetOffset = 28;

    /// <summary>
    /// Offset of number of buffers in header
    /// </summary>
    public const int NumberBufferOffset = 32;

    /// <summary>
    /// Offset of buffer length in header
    /// </summary>
    public const int BufferLengthOffset = 36;

    /// <summary>
    /// View of the memory mapped file used to retrieve data
    /// </summary>
    private readonly MemoryMappedViewAccessor FileMapView;
    public VariableBuffer buffer;

    public IRSDKHeader(MemoryMappedViewAccessor mapView)
    {
        FileMapView = mapView;
        buffer = new VariableBuffer(mapView, this);
    }

    public int Version => FileMapView.ReadInt32(VersionOffset);

    public int Status => FileMapView.ReadInt32(StatusOffset);

    public int TickRate => FileMapView.ReadInt32(TickRateOffset);

    public int SessionInfoUpdate => FileMapView.ReadInt32(SessionInfoUpdateOffset);

    public int SessionInfoLength => FileMapView.ReadInt32(SessionInfoLenngthOffset);

    public int SessionInfoOffset => FileMapView.ReadInt32(SessionInfoOffsetOffset);

    public int AmountOfVariables => FileMapView.ReadInt32(NumberOfVariablesOffset);

    public int VarHeaderOffset => FileMapView.ReadInt32(VariableHeaderOffsetOffset);

    public int BufferCount => FileMapView.ReadInt32(NumberBufferOffset);

    public int BufferLength => FileMapView.ReadInt32(BufferLengthOffset);

    public int Buffer => buffer.OffsetLatest;
}
