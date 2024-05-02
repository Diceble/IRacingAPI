using System.Runtime.InteropServices;

namespace IRacingSDK.Models;
//144 bytes
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct VarHeader
{
    //16 bytes: offset = 0
    public int type;
    //offset = 4
    public int offset;
    //offset = 8
    public int count;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public int[] pad;

    //32 bytes: offset = 16
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Definitions.MaxString)]
    public string name;
    //64 bytes: offset = 48
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Definitions.MaxDesc)]
    public string description;
    //32 bytes: offset = 112
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Definitions.MaxString)]
    public string unit;
}
