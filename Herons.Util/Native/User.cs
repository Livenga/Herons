namespace Herons.Util.Native;

using System;
using System.Runtime.InteropServices;


/// <summary></summary>
internal delegate bool MonitorEnumProc(
        IntPtr hWnd,
        IntPtr hDc,
        IntPtr lpRect,
        IntPtr lParam);


/// <summary></summary>
internal static class User
{
    /// <summary></summary>
    private const string LN = "user32.dll";


    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(EnumDisplayMonitors), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern bool EnumDisplayMonitors(
            [In]IntPtr          hdc,
            [In]IntPtr          lprcClip,
            [In]MonitorEnumProc lpfnEnum,
            [In]IntPtr          dwData);

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(GetMonitorInfoW), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Unicode)]
    internal static extern bool GetMonitorInfoW(
            [In]IntPtr hMonitor,
            [In, Out]ref MonitorInfoEx lpmi);

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(GetWindowDC), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern IntPtr GetWindowDC([In]IntPtr hWnd);

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(GetDC), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern IntPtr GetDC(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(ReleaseDC), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern int ReleaseDC(
            [In]IntPtr hWnd,
            [In]IntPtr hDC);


    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(GetWindowRect), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern bool GetWindowRect(
            [In]IntPtr hWnd,
            [Out]out Rect lpRect);
}
