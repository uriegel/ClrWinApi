using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace ClrWinApi;

[GeneratedComClass]
public partial class FormatEtcEnumerator : IEnumFORMATETC
{
    public static readonly Guid IID_IEnumFORMATETC = new("00000103-0000-0000-C000-000000000046");

    public FormatEtcEnumerator(FormatEtc[] formats, int index = 0)
    {
        this.formats = formats;
        this.index = index;
    }

    public int Next(uint celt, nint rgelt, nint pceltFetched)
    {
        if (rgelt == 0)
            return E_POINTER;

        if (celt != 1 && pceltFetched == 0)
            return E_POINTER;

        uint fetched = 0;
        int size = Marshal.SizeOf<FormatEtc>();

        while (fetched < celt && index < formats.Length)
        {
            nint destination = rgelt + (nint)(fetched * (uint)size);

            Marshal.StructureToPtr(formats[index], destination, false);
            index++;
            fetched++;
        }

        if (pceltFetched != 0)
            Marshal.WriteInt32(pceltFetched, (int)fetched);

        return fetched == celt ? S_OK : S_FALSE;
    }

    public int Skip(uint celt)
    {
        int remaining = formats.Length - index;
        int skipped = Math.Min((int)celt, remaining);

        index += skipped;

        return skipped == celt ? 0 : 1;
    }

    public int Reset()
    {
        index = 0;
        return 0;
    }

    public int Clone(out nint ppenum)
    {
        var clone = new FormatEtcEnumerator(formats, index);

        nint unknown = Wrappers.GetOrCreateComInterfaceForObject(
               clone,
               CreateComInterfaceFlags.None);

        int hr = Marshal.QueryInterface(unknown, in IID_IEnumFORMATETC, out ppenum);
        Marshal.Release(unknown);
        return hr;
    }

    const int S_OK = 0;
    const int S_FALSE = 1;
    const int E_POINTER = unchecked((int)0x80004003);

    static readonly StrategyBasedComWrappers Wrappers = new();
    readonly FormatEtc[] formats;
    int index;
}

