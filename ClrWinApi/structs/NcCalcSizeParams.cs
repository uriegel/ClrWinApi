using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct NcCalcSizeParams
{
    public static NcCalcSizeParams Fromnint(nint nint)
        => (NcCalcSizeParams)Marshal.PtrToStructure(nint, typeof(NcCalcSizeParams));

    public Rect Rgrc0;
    public Rect Rgrc1;
    public Rect Rgrc2;
    public WindowPos WindowPos;
}        
