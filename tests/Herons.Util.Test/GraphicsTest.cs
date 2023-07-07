namespace Herons.Util.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;


/// <summary></summary>
[TestClass]
public class GraphicsTest
{
    /// <summary></summary>
    [TestMethod]
    public void GetMonitorRectsTest()
    {
        var mis = Herons.Util.Graphics.GetMonitorRects();

        Console.WriteLine($"{mis.Length}");
        foreach(var mi in mis)
            Console.WriteLine($"{mi.Handle} {mi.Width}x{mi.Height}");
    }

    [TestMethod]
    public void CreateWindowBitmapTest()
    {
        var mis = Herons.Util.Graphics.GetMonitorRects();

        foreach(var mi in mis)
        {
            using var bmp = Graphics.CreateMonitorBitmap(mi);
            bmp.Save($"{Guid.NewGuid()}.jpg");
        }
    }
}
