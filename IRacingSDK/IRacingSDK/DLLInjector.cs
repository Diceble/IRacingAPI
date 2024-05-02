using System.Runtime.InteropServices;
using System.Security;

namespace IRacingAPI;
internal class DLLInjector
{
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    internal static extern nint OpenEvent(uint dwDesiredAccess, bool bInheritHandle, string lpName);

    [DllImport("kernel32.dll", SetLastError = true)]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CloseHandle(nint hObject);
}
