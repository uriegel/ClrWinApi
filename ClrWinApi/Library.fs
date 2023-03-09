module ClrWinApi 

open System
open System.Runtime.InteropServices

type FileFuncFlags =
    MOVE = 0x1
    | COPY = 0x2
    | DELETE = 0x3
    | RENAME = 0x4

type ShowWindowFlag = 
    Show = 5

type ShellExecuteFlag = 
    InvokeIDList = 12
    
[<Flags>]
type FileOpFlags = 
    MULTIDESTFILES = 0x1us
    | CONFIRMMOUSE = 0x2us
    /// <summary>
    /// Don't create progress/report
    /// </summary>
    | SILENT = 0x4us
    | RENAMEONCOLLISION = 0x8us
    /// <summary>
    /// Don't prompt the user.
    /// </summary>
    | NOCONFIRMATION = 0x10us
    /// <summary>
    /// Fill in SHFILEOPSTRUCT.hNameMappings.
    /// Must be freed using SHFreeNameMappings
    /// </summary>
    | WANTMAPPINGHANDLE = 0x20us
    | ALLOWUNDO = 0x40us
    /// <summary>
    /// On *.*, do only files
    /// </summary>
    | FILESONLY = 0x80us
    /// <summary>
    /// Don't show names of files
    /// </summary>
    | SIMPLEPROGRESS = 0x100us
    /// <summary>
    /// Don't confirm making any needed dirs
    /// </summary>
    | NOCONFIRMMKDIR = 0x200us
    /// <summary>
    /// Don't put up error UI
    /// </summary>
    | NOERRORUI = 0x400us
    /// <summary>
    /// Dont copy NT file Security Attributes
    /// </summary>
    | NOCOPYSECURITYATTRIBS = 0x800us
    /// <summary>
    /// Don't recurse into directories.
    /// </summary>
    | NORECURSION = 0x1000us
    /// <summary>
    /// Don't operate on connected elements.
    /// </summary>
    | NO_CONNECTED_ELEMENTS = 0x2000us
    /// <summary>
    /// During delete operation, 
    /// warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
    /// </summary>
    | WANTNUKEWARNING = 0x4000us
    /// <summary>
    /// Treat reparse points as objects, not containers
    /// </summary>
    | NORECURSEREPARSE = 0x8000us

[<Flags>]
type SHGetFileInfoConstants = 
    ICON = 0x100                 // get icon
    | DISPLAYNAME = 0x200        // get display name
    | TYPENAME = 0x400           // get type name
    | ATTRIBUTES = 0x800         // get attributes
    | ICONLOCATION = 0x1000      // get icon location
    | EXETYPE = 0x2000           // return exe type
    | SYSICONINDEX = 0x4000      // get system icon index
    | LINKOVERLAY = 0x8000       // put a link overlay on icon
    | SELECTED = 0x10000         // show icon in selected state
    | ATTRSPECIFIED = 0x20000    // get only specified attributes
    | LARGEICON = 0x0            // get large icon
    | SMALLICON = 0x1            // get small icon
    | OPENICON = 0x2             // get open icon
    | SHELLICONSIZE = 0x4        // get shell size icon
    | PIDL = 0x8                 // pszPath is a pidl
    | USEFILEATTRIBUTES = 0x10   // use passed dwFileAttribute
    | ADDOVERLAYS = 0x000000020  // apply the appropriate overlays
    | OVERLAYINDEX = 0x000000040 // Get the index of the overlay

[<Struct; StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)>]
type ShFileInfo =
    val mutable IconHandle: nativeint
    val mutable Icon: int
    val mutable Attributes: UInt32
    [<MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)>]
    val mutable DisplayName: string 
    [<MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)>]
    val mutable TypeName: string 

/// <summary>
/// [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
/// If you use the above you may encounter an invalid memory access exception (when using ANSI
/// or see nothing (when using unicode) when you use FOF_SIMPLEPROGRESS flag.
/// </summary>
[<Struct; StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)>]
type SHFILEOPSTRUCT = 
    val mutable Hwnd: IntPtr
    val mutable Func: FileFuncFlags
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable From: string
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable To: string
    val mutable Flags: FileOpFlags 
    [<MarshalAs(UnmanagedType.Bool)>]
    val mutable AnyOperationsAborted: bool
    val mutable NameMappings: IntPtr
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable ProgressTitle: String

[<Struct; StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)>]
type ShellExecuteInfo =
    val mutable Size: int
    val mutable Mask: ShellExecuteFlag
    val mutable Hwnd: IntPtr
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable Verb: string
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable File: string
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable Parameters: string
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable Directory: string
    val mutable Show: ShowWindowFlag
    val mutable InstApp: IntPtr
    val mutable IDList: IntPtr
    [<MarshalAs(UnmanagedType.LPWStr)>]
    val mutable Class: string
    val mutable HkeyClass: IntPtr
    val mutable HotKey: uint32
    val mutable Icon: IntPtr
    val mutable Monitor: IntPtr
    val mutable Process: IntPtr

let FileAttributeNormal = 0x80

[<DllImport("shell32")>]
extern nativeint SHGetFileInfo(string pszPath, int dwFileAttributes, ShFileInfo& psfi, int cbFileInfo, SHGetFileInfoConstants uFlags)
[<DllImport("user32.dll", SetLastError = true)>]
extern bool DestroyIcon(nativeint hIcon)
[<DllImport("kernel32.dll")>]
extern UInt32 GetCurrentThreadId()
[<DllImport("shell32.dll", CharSet = CharSet.Unicode)>]
extern int SHFileOperation(SHFILEOPSTRUCT fileOp)
[<DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)>]
extern bool ShellExecuteEx(ShellExecuteInfo& execInfo)

TODO port to C#
TODO version 2.0
TODO static class Api
TODO
TODO using static Api
TODO Namespace image.png
TODO xml doku in nuget