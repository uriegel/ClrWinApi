using System.Runtime.InteropServices;

namespace ClrWinApi;

[ComImport]
[Guid("3D25F6D6-4B2A-433C-9184-7C33AD35D001")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IDataObjectProvider
{
    [PreserveSig]
    int GetDataObject(out nint dataObject);

    [PreserveSig]
    int SetDataObject(nint dataObject);
}
