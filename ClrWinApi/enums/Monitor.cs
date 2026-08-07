namespace ClrWinApi;

[Flags]
public enum MonitorDefaultTo
{
    Null,
    /// <summary>
    /// Display monitor that is nearest to the rectangle.
    /// </summary>
    Nearest,
    /// <summary>
    /// The primary display monitor.
    /// </summary>
    Primary
}
