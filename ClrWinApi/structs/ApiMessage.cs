using System.Runtime.InteropServices;

namespace ClrWinApi;

[StructLayout(LayoutKind.Sequential)]
public struct ApiMessage
{
    /// <summary>
    /// Das Fenster, welches die Nachricht bekommen soll/hat
    /// </summary>
    public nint Window;
    /// <summary>
    /// Die Art der Nachricht
    /// </summary>
    public uint MessageType;
    public nint WParam;
    public nint LParam;
    public uint Time;
    public MousePoint MousePoint;
}