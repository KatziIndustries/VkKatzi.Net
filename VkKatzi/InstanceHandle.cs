namespace VkKatzi;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct InstanceHandle
{
    public readonly nint Handle;

    public InstanceHandle(nint handle) => Handle = handle;

    public static implicit operator nint(InstanceHandle h) => h.Handle;
    public static implicit operator InstanceHandle(nint h) => new(h);

    public bool IsNull => Handle == 0;
}