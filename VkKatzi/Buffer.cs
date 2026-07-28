using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Buffer
{
    public readonly nint Handle;

    public Buffer(nint handle) => Handle = handle;

    public static implicit operator nint(Buffer h) => h.Handle;
    public static implicit operator Buffer(nint h) => new(h);

    public bool IsNull => Handle == 0;
}