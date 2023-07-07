namespace Herons.Util.Native;

using System.Runtime.InteropServices;


/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int Left;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int Top;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int Right;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int Bottom;
}
