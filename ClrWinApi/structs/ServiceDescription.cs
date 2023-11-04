using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct ServiceDescription
{
    public string Description;
}
