namespace VkKatzi;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct PipelineHandle
{
    public readonly nint Handle;

    public PipelineHandle(nint handle) => Handle = handle;

    public static implicit operator nint(PipelineHandle h) => h.Handle;
    public static implicit operator PipelineHandle(nint h) => new(h);

    public bool IsNull => Handle == 0;
}