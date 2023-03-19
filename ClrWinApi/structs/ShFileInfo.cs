using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct ShFileInfo 
{
    public IntPtr IconHandle;
    public int Icon;
    public uint Attributes;

    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string DisplayName;
   
    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string TypeName; 
}
