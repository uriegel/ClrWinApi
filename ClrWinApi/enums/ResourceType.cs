namespace ClrWinApi;

[Flags]
public enum ResourceType 
{
    Any = 0,
    Disk = 1,
    Print = 2,
    Reserved = 8,
}

