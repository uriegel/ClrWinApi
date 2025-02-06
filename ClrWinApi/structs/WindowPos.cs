using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct WindowPos
{
    public nint Wnd;
    public nint WndInsertAfter;
    public int X;
    public int Y;
    public int XWidth;
    public int YWidth;
    public int Flags;
}
