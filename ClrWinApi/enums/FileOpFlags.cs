namespace ClrWinApi;

[Flags]
public enum FileOpFlags: ushort
{
    MULTIDESTFILES = 0x1,
    CONFIRMMOUSE = 0x2,
    /// <summary>
    /// Don't create progress/report
    /// </summary>
    SILENT = 0x4,
    RENAMEONCOLLISION = 0x8,
    /// <summary>
    /// Don't prompt the user.
    /// </summary>
    NOCONFIRMATION = 0x10,
    /// <summary>
    /// Fill in SHFILEOPSTRUCT.hNameMappings.
    /// Must be freed using SHFreeNameMappings
    /// </summary>
    WANTMAPPINGHANDLE = 0x20,
    ALLOWUNDO = 0x40,
    /// <summary>
    /// On *.*, do only files
    /// </summary>
    FILESONLY = 0x80,
    /// <summary>
    /// Don't show names of files
    /// </summary>
    SIMPLEPROGRESS = 0x100,
    /// <summary>
    /// Don't confirm making any needed dirs
    /// </summary>
    NOCONFIRMMKDIR = 0x200,
    /// <summary>
    /// Don't put up error UI
    /// </summary>
    NOERRORUI = 0x400,
    /// <summary>
    /// Dont copy NT file Security Attributes
    /// </summary>
    NOCOPYSECURITYATTRIBS = 0x800,
    /// <summary>
    /// Don't recurse into directories.
    /// </summary>
    NORECURSION = 0x1000,
    /// <summary>
    /// Don't operate on connected elements.
    /// </summary>
    NO_CONNECTED_ELEMENTS = 0x2000,
    /// <summary>
    /// During delete operation, 
    /// warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
    /// </summary>
    WANTNUKEWARNING = 0x4000,
    /// <summary>
    /// Treat reparse points as objects, not containers
    /// </summary>
    NORECURSEREPARSE = 0x8000
}
