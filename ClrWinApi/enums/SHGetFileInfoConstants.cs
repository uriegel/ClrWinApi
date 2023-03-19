namespace ClrWinApi;

[Flags]
public enum SHGetFileInfoConstants
{
    /// <summary>
    /// get icon
    /// </summary>
    ICON = 0x100,                 

    /// <summary>
    /// get display name
    /// </summary>
    DISPLAYNAME = 0x200,        

    /// <summary>
    /// get type name
    /// </summary>
    TYPENAME = 0x400,           

    /// <summary>
    /// get attributes
    /// </summary>
    ATTRIBUTES = 0x800,         

    /// <summary>
    /// get icon location
    /// </summary>
    ICONLOCATION = 0x1000,      

    /// <summary>
    /// return exe type
    /// </summary>
    EXETYPE = 0x2000,           

    /// <summary>
    /// get system icon index
    /// </summary>
    SYSICONINDEX = 0x4000,      

    /// <summary>
    /// put a link overlay on icon
    /// </summary>
    LINKOVERLAY = 0x8000,       

    /// <summary>
    /// show icon in selected state
    /// </summary>
    SELECTED = 0x10000,         
    
    /// <summary>
    /// get only specified attributes
    /// </summary>
    ATTRSPECIFIED = 0x20000,    

    /// <summary>
    /// get large icon
    /// </summary>
    LARGEICON = 0x0,            

    /// <summary>
    /// get small icon
    /// </summary>
    SMALLICON = 0x1,            

    /// <summary>
    /// get open icon
    /// </summary>
    OPENICON = 0x2,             

    /// <summary>
    /// get shell size icon
    /// </summary>
    SHELLICONSIZE = 0x4,        

    /// <summary>
    /// pszPath is a pidl
    /// </summary>
    PIDL = 0x8,                 

    /// <summary>
    /// use passed dwFileAttribute
    /// </summary>
    USEFILEATTRIBUTES = 0x10,   

    /// <summary>
    /// apply the appropriate overlays
    /// </summary>
    ADDOVERLAYS = 0x000000020,  

    /// <summary>
    /// Get the index of the overlay
    /// </summary>
    OVERLAYINDEX = 0x000000040, 
}