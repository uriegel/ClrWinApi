using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct NcCalcSizeParams
{
    public static NcCalcSizeParams FromIntPtr(nint nint) => Marshal.PtrToStructure<NcCalcSizeParams>(nint);

    public Rect Rgrc0;
    public Rect Rgrc1;
    public Rect Rgrc2;
    public WindowPos WindowPos;
}        
