using System.Runtime.InteropServices;
using System.Security;

namespace IRacingSDK;
internal class DLLInjector
{
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr OpenEvent(UInt32 dwDesiredAccess, Boolean bInheritHandle, String lpName);

    [DllImport("kernel32.dll", SetLastError = true)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CloseHandle(IntPtr hObject);
}
