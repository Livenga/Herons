namespace Herons.Util.Native;

using System.Runtime.InteropServices;


internal static class Kernel
{
    private const string LN = "kernel32.dll";

    /// <summary></summary>
    [DllImport(LN, EntryPoint = nameof(GetLastError), SetLastError = true, ExactSpelling = false, CharSet = CharSet.Auto)]
    internal static extern int GetLastError();
}
