namespace Herons.Util.Native;

using System;
using System.Runtime.InteropServices;


/// <summary></summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct MonitorInfoEx
{
    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int cbSize;

    /// <summary></summary>
    public Rect rcMonitor;

    /// <summary></summary>
    public Rect rcWork;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.I4)]
    public int dwFlags;

    /// <summary></summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 31)]
    public char[] szDevice;
}
