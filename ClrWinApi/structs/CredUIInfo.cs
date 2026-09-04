using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct CredUIInfo
{
    public int Size;
    public nint Parent;
    public string? MessageText;
    public string? CaptionText;
    public nint Banner;
}
