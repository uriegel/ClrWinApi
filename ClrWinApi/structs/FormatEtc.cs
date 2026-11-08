using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct FormatEtc
{
    public ushort cfFormat;
    public nint ptd;
    public uint dwAspect;
    public int lindex;
    public uint tymed;
}
