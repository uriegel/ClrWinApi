using System.Runtime.InteropServices;

namespace ClrWinApi;

public static class Api
{
    const uint ERROR_INSUFFICIENT_BUFFER = 122;

    [DllImport("Advapi32.dll", SetLastError = true)]
    public extern static int RegNotifyChangeKeyValue(nint hKey, bool watchSubtree, int types, nint hEvent, bool asynchronous);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern nint OpenSCManager(string? machineName, string? databaseName, ServicesControlManagerDesiredAccess desiredAccess);

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern nint OpenService(nint serviceControlManager, string serviceName, ServicesControlManagerDesiredAccess desiredAccess);

    public static string? GetServiceDescription(nint service)
    {
        var success = QueryServiceConfig2(service, ServiceConfig.Description, 0, 0, out var bytesNeeded);
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
    public static extern bool QueryServiceConfig2(nint service, ServiceConfig infoLevel, nint buffer, uint bufferSize, out uint bytesNeeded);
    
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool CloseServiceHandle(nint ServiceControlObject);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]    
    public static extern bool DestroyIcon(nint hIcon);

    [DllImport("user32.dll")]
    public static extern void PostQuitMessage(int exitCode);
    
    [DllImport("user32.dll")]
    public static extern sbyte GetMessage(out ApiMessage message, nint hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    
    [DllImport("user32.dll")]
    public static extern nint DispatchMessage([In] ref ApiMessage message);

    [DllImport("user32.dll")]
    public static extern int FindWindow(string className, string windowText);
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]   
    public static extern bool ShowWindow(nint hwnd, ShowWindowFlag command);

    [DllImport("user32.dll")]
    public static extern nint FindWindowEx(nint parentHandle, nint childAfter, string? className, string? windowTitle);

    [DllImport("user32.dll")]
    public static extern int GetDesktopWindow();

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsZoomed(IntPtr hWnd);

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern nint LoadLibrary(string filename);
    
    [DllImport("kernel32.dll")]
    public static extern uint GetCurrentThreadId();

    [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CopyFileEx(string existingFileName, string newFileName,
        CopyProgressRoutine progressRoutine, nint data, ref int cancel, CopyFileFlags copyFlags);

    [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool MoveFileWithProgress(string existingFileName, string newFileName, 
        CopyProgressRoutine progressRoutine, nint data, MoveFileFlags flags);
        
    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    public static extern int SHFileOperation(ShFileOPStruct fileOp);
    
    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ShellExecuteEx(ref ShellExecuteInfo execInfo);

    [DllImport("shell32")]
    public static extern nint SHGetFileInfo(string pszPath, FileAttributes fileAttributes, ref ShFileInfo psfi, int cbFileInfo, SHGetFileInfoConstants uFlags);
    [DllImport("shell32")]
    public static extern nint SHGetFileInfo(string pszPath, int dwFileAttributes, ref ShFileInfo psfi, int cbFileInfo, SHGetFileInfoConstants uFlags);

    [DllImport("mpr.dll")]
    public static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

    [DllImport("mpr.dll")]
    public static extern int WNetCancelConnection2(string name, int flags, bool force);

    [DllImport("DwmApi")]
    public static extern int DwmSetWindowAttribute(nint hwnd, DwmWindowAttribute attr, int[] attrValue, int attrSize);
}

