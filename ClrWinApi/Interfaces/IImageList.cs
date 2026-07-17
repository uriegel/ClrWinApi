using System.Runtime.InteropServices;

namespace ClrWinApi;

[ComImport]
[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IImageList
{
    [PreserveSig]
    int Add(nint hbmImage, nint hbmMask, out int pi);

    [PreserveSig]
    int ReplaceIcon(int i, nint hicon, out int pi);

    [PreserveSig]
    int SetOverlayImage(int iImage, int iOverlay);

    [PreserveSig]
    int Replace(int i, nint hbmImage, nint hbmMask);

    [PreserveSig]
    int AddMasked(nint hbmImage, uint crMask, out int pi);

    [PreserveSig]
    int Draw(nint pimldp);

    [PreserveSig]
    int Remove(int i);

    [PreserveSig]
    int GetIcon(int i, ImageListDrawFlags flags, out nint phicon);
}