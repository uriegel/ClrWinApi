using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct ApiMessage
{
    /// <summary>
    /// Das Fenster, welches die Nachricht bekommen soll/hat
    /// </summary>
    public IntPtr Window;
    /// <summary>
    /// Die Art der Nachricht
    /// </summary>
    public UInt32 MessageType;
    public IntPtr WParam;
    public IntPtr LParam;
    public UInt32 Time;
    public MousePoint MousePoint;
}