namespace VkKatzi;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct BufferHandle
{
    public readonly nint Handle;

    public BufferHandle(nint handle) => Handle = handle;

    public static implicit operator nint(BufferHandle h) => h.Handle;
    public static implicit operator BufferHandle(nint h) => new(h);

    public bool IsNull => Handle == 0;
}