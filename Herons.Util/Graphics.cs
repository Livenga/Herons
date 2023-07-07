namespace Herons.Util;

using WinGraphics = System.Drawing.Graphics;
using Herons.Util.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;


/// <summary></summary>
public static class Graphics
{
    private static List<MonitorInfo>? _monitorInfos = null;

    /// <summary></summary>
    public static MonitorInfo[] GetMonitorRects()
    {
        if(_monitorInfos != null)
            throw new Exception();
        _monitorInfos = new ();

        User.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, OnMonitorEnumProc, IntPtr.Zero);

        var ret = _monitorInfos.ToArray();

        _monitorInfos.Clear();
        _monitorInfos = null;

        return ret;
    }

    /// <summary></summary>
    private static bool OnMonitorEnumProc(
            IntPtr hMonitor,
            IntPtr hDc,
            IntPtr lpRect,
            IntPtr lParam)
    {
        if(_monitorInfos == null)
            return false;

        _monitorInfos.Add(
                new MonitorInfo(
                    handle:    hMonitor,
                    rectangle: Marshal.PtrToStructure<Rect>(lpRect),
                    name:      TryGetMonitorName(hMonitor)));

        return true;
    }

    /// <summary></summary>
    private static string GetMonitorName(IntPtr hMonitor)
    {
        var exInfo = new MonitorInfoEx();

        exInfo.cbSize = Marshal.SizeOf<MonitorInfoEx>();
        var ret = User.GetMonitorInfoW(hMonitor, ref exInfo);
        if(! ret)
            throw new Win32Exception(Kernel.GetLastError());

        return new string(exInfo.szDevice).Split('\0')[0];
    }

    /// <summary></summary>
    private static string? TryGetMonitorName(
            IntPtr hMonitor,
            string? defValue = null)
    {
        try
        {
            return GetMonitorName(hMonitor);
        }
        catch
        {
            return defValue;
        }
    }


    /// <summary></summary>
    private static IntPtr CreateMonitorDCW(string str)
    {
        var hDevice = Marshal.StringToHGlobalUni(str);

        var handle = Gdi.CreateDCW(IntPtr.Zero, hDevice, IntPtr.Zero, IntPtr.Zero);

        Marshal.FreeHGlobal(hDevice);

        return handle;
    }


    /// <summary></summary>
    public static Bitmap CreateWindowBitmap(IntPtr hWnd)
    {
        Rect rect;
        if(! User.GetWindowRect(hWnd, out rect))
            throw new Win32Exception(Kernel.GetLastError());

        //var hdc = User.GetDC(hWnd);
        var hdc = User.GetWindowDC(hWnd);
        var bmp = CreateBitmapFromHdc(
                hdc,
                rect.Right  - rect.Left,
                rect.Bottom - rect.Top);

        User.ReleaseDC(hWnd, hdc);

        return bmp;
    }

    /// <summary></summary>
    public static Bitmap CreateMonitorBitmap(MonitorInfo mi)
    {
        var h = CreateMonitorDCW(mi.Name ?? throw new NullReferenceException());

        var bmp = CreateBitmapFromHdc(h, mi.Width, mi.Height);

        Gdi.DeleteDC(h);

        return bmp;
    }

    /// <summary></summary>
    public static Bitmap CreateBitmapFromHdc(
            IntPtr hdc,
            int    width,
            int    height)
    {
        if(hdc == IntPtr.Zero)
            throw new NullReferenceException();

        using var gDc = WinGraphics.FromHdc(hdc);
        var bmp = new Bitmap(width, height, gDc);

        bool result;
        using(var gDest = WinGraphics.FromImage(bmp))
        {
            var hDest = gDest.GetHdc();
            result = Native.Gdi.BitBlt(
                    hDest, 0, 0, width, height,
                    hdc,   0, 0,
                    0x00CC0020);
            gDest.ReleaseHdc(hDest);
        }

        return bmp;
    }
}
