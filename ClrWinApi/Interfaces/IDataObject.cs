using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace ClrWinApi;

[GeneratedComInterface]
[Guid("0000010E-0000-0000-C000-000000000046")]
public partial interface IDataObject
{
    [PreserveSig]
    int GetData(nint formatEtc, nint medium);

    [PreserveSig]
    int GetDataHere(nint pFormatEtc, nint Medium);

    [PreserveSig]
    int QueryGetData(nint pFormatEtc);

    [PreserveSig]
    int GetCanonicalFormatEtc(nint pFormatEtcIn, nint pFormatEtcOut);

    [PreserveSig]
    int SetData(nint pFormatEtc, nint pMedium, int fRelease);

    [PreserveSig]
    int EnumFormatEtc(uint dwDirection, nint ppenumFormatEtc);

    [PreserveSig]
    int DAdvise(nint pFormatEtc, uint advf, nint pAdvSink, nint pdwConnection);

    [PreserveSig]
    int DUnadvise(uint dwConnection);

    [PreserveSig]
    int EnumDAdvise(nint ppenumAdvise);
}
