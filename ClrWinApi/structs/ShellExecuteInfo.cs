using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct ShellExecuteInfo
{
    public int Size;
    public ShellExecuteFlag Mask;
    public nint Hwnd; 
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Verb;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string File;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Parameters;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Directory;
    public ShowWindowFlag Show;
    public nint InstApp;
    public nint IDList;
    
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Class;
    public nint HkeyClass;
    public uint HotKey;
    public nint Icon;
    public nint Process;
}