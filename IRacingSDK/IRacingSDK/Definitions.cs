namespace IRacingSDK;
internal class Definitions
{
    public const uint DesiredAccess = 2031619;
    public const string DataValidEventName = "Local\\IRSDKDataValidEvent";

    /// <summary>
    /// This is the name of the memory mapped file that iRacing uses to share data with external applications
    /// </summary>
    public const string MemMapFileName = "Local\\IRSDKMemMapFileName";
    public const string BroadcastMessageName = "IRSDK_BROADCASTMSG";
    public const string PadCarNumName = "IRSDK_PADCARNUM";
    public const int MaxString = 32;
    public const int MaxDesc = 64;
    public const int MaxVars = 4096;
    public const int MaxBufs = 4;
    public const int StatusConnected = 1;
}
