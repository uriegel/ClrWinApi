
namespace ClrWinApi;

[Flags]
public enum CopyFileFlags : uint
{
    FailIfExists = 0x00000001,
    Restartable  = 0x00000002,
    OpenSourceForWrite = 0x00000004,
    AllowDecryptedDestination = 0x00000008,
    CopySymlink        = 0x00000800, 
    NoBuffering        = 0x00001000 
}