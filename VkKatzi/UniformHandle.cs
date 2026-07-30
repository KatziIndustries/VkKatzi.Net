using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public readonly struct UniformHandle
{
    public readonly nint Handle;

    public UniformHandle(nint handle) => Handle = handle;

    public static implicit operator nint(UniformHandle h) => h.Handle;
    public static implicit operator UniformHandle(nint h) => new(h);

    public bool IsNull => Handle == 0;
}