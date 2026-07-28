using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Uniform
{
    public readonly nint Handle;

    public Uniform(nint handle) => Handle = handle;

    public static implicit operator nint(Uniform h) => h.Handle;
    public static implicit operator Uniform(nint h) => new(h);

    public bool IsNull => Handle == 0;
}