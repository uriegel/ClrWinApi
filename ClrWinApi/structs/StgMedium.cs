using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct StgMedium
{
    public uint tymed;
    public nint unionmember;
    public nint pUnkForRelease;
}
