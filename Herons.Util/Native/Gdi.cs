namespace Herons.Util.Native;

using System;
using System.Runtime.InteropServices;


/// <summary></summary>
internal static class Gdi
{
    /// <summary></summary>
    private const string LN = "gdi32.dll";


    /// <summary>
    /// </summary>
    /// <remarks>
    /// 参照 <see href="https://learn.microsoft.com/ja-jp/windows/win32/api/wingdi/nf-wingdi-bitblt"></see>
    /// </remarks>
    [DllImport(LN, EntryPoint = nameof(BitBlt), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern bool BitBlt(
            IntPtr hdc,
            int x,
            int y,
            int cx,
            int cy,
            IntPtr hdcSrc,
            int x1,
            int y1,
            int rop);

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(CreateDCW), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateDCW(
            IntPtr pwszDriver,
            [In]IntPtr pwszDevice,
            IntPtr pszPort,
            [In]IntPtr pdm);

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(DeleteDC), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern bool DeleteDC([In]IntPtr hdc);
}
