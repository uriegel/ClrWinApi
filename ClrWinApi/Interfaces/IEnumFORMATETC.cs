using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace ClrWinApi;

[GeneratedComInterface]
[Guid("00000103-0000-0000-C000-000000000046")]
public  partial interface IEnumFORMATETC
{
    [PreserveSig]
    int Next(uint celt, nint rgelt, nint pceltFetched);

    [PreserveSig]
    int Skip(uint celt);

    [PreserveSig]
    int Reset();

    [PreserveSig]
    int Clone(out nint ppenum);
}
