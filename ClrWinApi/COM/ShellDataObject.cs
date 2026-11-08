using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace ClrWinApi;

[GeneratedComClass]
public partial class ShellDataObject : IDataObject
{
    public const ushort CF_HDROP = 15;
    public const uint DVASPECT_CONTENT = 1;
    public const uint TYMED_HGLOBAL = 1;
    public const uint DROPEFFECT_COPY = 1;
    public const uint DROPEFFECT_MOVE = 2;
    public static readonly ushort CF_PREFERREDDROPEFFECT = Api.RegisterClipboardFormat(CFSTR_PREFERREDDROPEFFECT);
    
    public ShellDataObject(string[] filePaths) => this.filePaths = filePaths;

    public int QueryGetData(nint pFormatEtc)
    {
        if (pFormatEtc == 0)
            return E_POINTER;

        var format = Marshal.PtrToStructure<FormatEtc>(pFormatEtc);

        if (format.cfFormat != CF_HDROP)
            return DV_E_FORMATETC;
        if (format.ptd != 0)
            return DV_E_DVTARGETDEVICE;
        if (format.dwAspect != DVASPECT_CONTENT)
            return DV_E_DVASPECT;
        if (format.lindex != -1)
            return DV_E_LINDEX;
        if ((format.tymed & TYMED_HGLOBAL) == 0)
            return DV_E_TYMED;

        return S_OK;
    }

    public int GetData(nint pFormatEtc, nint pMedium)
    {
        if (pMedium == 0)
            return E_POINTER;

        int result = QueryGetData(pFormatEtc);

        if (result != S_OK)
            return result;

        Marshal.StructureToPtr(new StgMedium(), pMedium, false);

        nint memory = 0;

        try
        {
            // DROPFILES header followed by UTF-16 paths.
            string paths = string.Join('\0', filePaths) + "\0\0";
            byte[] pathBytes = Encoding.Unicode.GetBytes(paths);

            int headerSize = Marshal.SizeOf<DropFiles>();
            int totalSize = checked(headerSize + pathBytes.Length);

            memory = Api.GlobalAlloc(GMEM_MOVEABLE, (nuint)totalSize);

            if (memory == 0)
                return E_OUTOFMEMORY;

            nint pointer = Api.GlobalLock(memory);

            if (pointer == 0)
            {
                Api.GlobalFree(memory);
                return E_OUTOFMEMORY;
            }

            try
            {
                var dropFiles = new DropFiles
                {
                    pFiles = headerSize,
                    fWide = 1
                };

                Marshal.StructureToPtr(dropFiles, pointer, false);

                Marshal.Copy(pathBytes, 0, pointer + headerSize, pathBytes.Length);
            }
            finally
            {
                Api.GlobalUnlock(memory);
            }

            // Transfer ownership of the HGLOBAL to the caller.
            Marshal.StructureToPtr(new StgMedium
                {
                    tymed = TYMED_HGLOBAL,
                    unionmember = memory,
                    pUnkForRelease = 0
                }, pMedium, false);

            memory = 0;
            return S_OK;
        }
        catch
        {
            if (memory != 0)
                Api.GlobalFree(memory);

            throw;
        }
    }

    public int GetDataHere(nint pFormatEtc, nint pMedium) => unchecked((int)0x80004001);

    public int GetCanonicalFormatEtc(nint pFormatEtcIn, nint pFormatEtcOut) => unchecked((int)0x80004001);

    public int SetData(nint pFormatEtc, nint pMedium, int fRelease) => unchecked((int)0x80004001);

    public int EnumFormatEtc(uint dwDirection, nint ppenumFormatEtc)
    {
        const uint DATADIR_GET = 1;

        if (ppenumFormatEtc == 0)
            return E_POINTER;

        Marshal.WriteIntPtr(ppenumFormatEtc, 0);

        if (dwDirection != DATADIR_GET)
            return unchecked((int)0x80004001); // E_NOTIMPL

        var format = new FormatEtc
        {
            cfFormat = CF_HDROP,
            ptd = 0,
            dwAspect = DVASPECT_CONTENT,
            lindex = -1,
            tymed = TYMED_HGLOBAL
        };

        var formats = new[]
        {
            new FormatEtc
            {
                cfFormat = CF_HDROP,
                dwAspect = DVASPECT_CONTENT,
                lindex = -1,
                tymed = TYMED_HGLOBAL
            },
            new FormatEtc
            {
                cfFormat = CF_PREFERREDDROPEFFECT,
                dwAspect = DVASPECT_CONTENT,
                lindex = -1,
                tymed = TYMED_HGLOBAL
            }
        };

        var enumerator = new FormatEtcEnumerator(formats);
        var wrappers = new StrategyBasedComWrappers();
        nint ptr = wrappers.GetOrCreateComInterfaceForObject(
            enumerator,
            CreateComInterfaceFlags.None);

        Marshal.WriteIntPtr(ppenumFormatEtc, ptr);

        return S_OK;
    }

    public int DAdvise(nint pFormatEtc, uint advf, nint pAdvSink, nint pdwConnection) => unchecked((int)0x80004001);

    public int DUnadvise(uint dwConnection) => unchecked((int)0x80004001);

    public int EnumDAdvise(nint ppenumAdvise) => unchecked((int)0x80004001);

    const string CFSTR_PREFERREDDROPEFFECT = "Preferred DropEffect";
    const uint GMEM_MOVEABLE = 0x0002;
    const int S_OK = 0;
    const int E_POINTER = unchecked((int)0x80004003);
    const int DV_E_FORMATETC = unchecked((int)0x80040064);
    const int DV_E_DVTARGETDEVICE = unchecked((int)0x80040065);
    const int DV_E_DVASPECT = unchecked((int)0x8004006B);
    const int DV_E_LINDEX = unchecked((int)0x80040068);
    const int DV_E_TYMED = unchecked((int)0x80040069);
    const int E_OUTOFMEMORY = unchecked((int)0x8007000E);

    readonly string[] filePaths;
}

