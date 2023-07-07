namespace Herons.Util.Extends;

using System;


/// <summary></summary>
internal static class ExtendedIntPtr
{
    /// <summary></summary>
    public static long ToInt(this IntPtr p) => IntPtr.Size switch
    {
        8 => p.ToInt64(),
        _ => p.ToInt32(),
    };
}
