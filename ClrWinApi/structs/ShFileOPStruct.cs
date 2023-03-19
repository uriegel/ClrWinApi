using System.Runtime.InteropServices;

namespace ClrWinApi;

/// <summary>
/// [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
/// If you use the above you may encounter an invalid memory access exception (when using ANSI
/// or see nothing (when using unicode) when you use FOF_SIMPLEPROGRESS flag.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct ShFileOPStruct
{
    public IntPtr Hwnd;
    public FileFuncFlags Func;

    [MarshalAs(UnmanagedType.LPWStr)]
    public string From;

    [MarshalAs(UnmanagedType.LPWStr)]
    public string To;

    public FileOpFlags Flags;

    [MarshalAs(UnmanagedType.Bool)]
    public bool AnyOperationsAborted;

    public IntPtr NameMappings;

    [MarshalAs(UnmanagedType.LPWStr)]
    public string ProgressTitle;
}
