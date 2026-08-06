namespace VkKatzi;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct SurfaceHandle
{
    public readonly nint Handle;

    public SurfaceHandle(nint handle) => Handle = handle;

    public static implicit operator nint(SurfaceHandle h) => h.Handle;
    public static implicit operator SurfaceHandle(nint h) => new(h);

    public bool IsNull => Handle == 0;
}