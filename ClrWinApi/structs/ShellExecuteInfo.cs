using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct ShellExecuteInfo
{
    public int Size;
    public ShellExecuteFlag Mask;
    public IntPtr Hwnd; 
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Verb;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string File;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Parameters;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Directory;
    public ShowWindowFlag Show;
    public IntPtr InstApp;
    public IntPtr IDList;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Class;
    public IntPtr HkeyClass;
    public uint HotKey;
    public IntPtr Icon;
    public IntPtr Process;
}