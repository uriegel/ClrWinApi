using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]

public struct DropFiles
{
    public int pFiles;
    public int x;
    public int y;
    public int fNC;
    public int fWide;
}
