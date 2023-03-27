namespace ClrWinApi;

public enum CopyProgressCallbackReason : uint
{
    ChunkFinished = 0x00000000,
    StreamSwitch
}