namespace Herons.Util;

using Herons.Util.Native;
using System;


/// <summary></summary>
public class MonitorInfo
{
    /// <summary></summary>
    public IntPtr Handle { get; }

    /// <summary></summary>
    public Rect Rectangle { get; }

    /// <summary></summary>
    public string? Name { get; }


    /// <summary></summary>
    public int Width  => (Rectangle.Right - Rectangle.Left);

    /// <summary></summary>
    public int Height => (Rectangle.Bottom - Rectangle.Top);


    /// <summary></summary>
    public MonitorInfo(
            IntPtr handle,
            Rect rectangle,
            string? name)
    {
        Handle    = handle;
        Rectangle = rectangle;
        Name = name;
    }
}
