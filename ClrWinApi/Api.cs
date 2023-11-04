using System.Runtime.InteropServices;

namespace ClrWinApi;

public static class Api
{
    const uint ERROR_INSUFFICIENT_BUFFER = 122;

    [DllImport("Advapi32.dll", SetLastError = true)]
    public extern static int RegNotifyChangeKeyValue(IntPtr hKey, bool watchSubtree, int types, IntPtr hEvent, bool asynchronous);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr OpenSCManager(string? machineName, string? databaseName, ServicesControlManagerDesiredAccess desiredAccess);

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr OpenService(IntPtr serviceControlManager, string serviceName, ServicesControlManagerDesiredAccess desiredAccess);

    public static string? GetServiceDescription(IntPtr service)
    {
        var success = QueryServiceConfig2(service, ServiceConfig.Description, IntPtr.Zero, 0, out var bytesNeeded);
        if (!success && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
        {
            var buffer = Marshal.AllocHGlobal((int)bytesNeeded);
            success = QueryServiceConfig2(service, ServiceConfig.Description, buffer, bytesNeeded, out bytesNeeded);
            if (!success)
                return null;
            var description = (ServiceDescription)Marshal.PtrToStructure(buffer, typeof(ServiceDescription));
            Marshal.FreeHGlobal(buffer);
            return description.Description;
        }
        else
            return null;
    }

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool QueryServiceConfig2(IntPtr service, ServiceConfig infoLevel, IntPtr buffer, uint bufferSize, out uint bytesNeeded);
    
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool CloseServiceHandle(IntPtr ServiceControlObject);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]    
    public static extern bool DestroyIcon(IntPtr hIcon);

    [DllImport("user32.dll")]
    public static extern void PostQuitMessage(int exitCode);
    
    [DllImport("user32.dll")]
    public static extern sbyte GetMessage(out ApiMessage message, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    
    [DllImport("user32.dll")]
    public static extern IntPtr DispatchMessage([In] ref ApiMessage message);
    
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr LoadLibrary(string filename);
    
    [DllImport("kernel32.dll")]
    public static extern uint GetCurrentThreadId();

    [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CopyFileEx(string existingFileName, string newFileName,
        CopyProgressRoutine progressRoutine, IntPtr data, ref int cancel, CopyFileFlags copyFlags);

    [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MoveFileWithProgress(string existingFileName, string newFileName, 
        CopyProgressRoutine progressRoutine, IntPtr data, MoveFileFlags flags);
        
    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    public static extern int SHFileOperation(ShFileOPStruct fileOp);
    
    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ShellExecuteEx(ref ShellExecuteInfo execInfo);

    [DllImport("shell32")]
    public static extern IntPtr SHGetFileInfo(string pszPath, FileAttributes fileAttributes, ref ShFileInfo psfi, int cbFileInfo, SHGetFileInfoConstants uFlags);
    [DllImport("shell32")]
    public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref ShFileInfo psfi, int cbFileInfo, SHGetFileInfoConstants uFlags);
}

