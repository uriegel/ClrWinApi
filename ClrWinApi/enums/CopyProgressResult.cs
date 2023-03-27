namespace ClrWinApi;

public enum CopyProgressResult : uint
{
    Continue = 0,
    Cancel,
    Stop, 
    Quiet
}