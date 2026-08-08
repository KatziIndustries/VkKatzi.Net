namespace VkKatzi;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct TextureHandle
{
    public readonly nint Handle;

    public TextureHandle(nint handle) => Handle = handle;

    public static implicit operator nint(TextureHandle h) => h.Handle;
    public static implicit operator TextureHandle(nint h) => new(h);

    public bool IsNull => Handle == 0;
}