using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Window
{
    public readonly nint Handle;

    public Window(nint handle) => Handle = handle;

    public static implicit operator nint(Window h) => h.Handle;
    public static implicit operator Window(nint h) => new(h);

    public bool IsNull => Handle == 0;
}