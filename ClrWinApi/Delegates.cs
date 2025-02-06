namespace ClrWinApi;

public delegate CopyProgressResult CopyProgressRoutine(
    long totalFileSize,
    long totalBytesTransferred,
    long streamSize,
    long streamBytesTransferred,
    uint streamNumber,
    CopyProgressCallbackReason dwCallbackReason,
    nint sourceFile,
    nint destinationFile,
    nint data);