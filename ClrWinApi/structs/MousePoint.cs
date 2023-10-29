using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct MousePoint
{ 
    public int X;
    public int Y;
}