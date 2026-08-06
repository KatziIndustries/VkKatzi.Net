using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PipelineDescription
{
    public required string VertexShaderPath;
    public required string FragmentShaderPath;
    public required VertexAttribute* VertexAttributes;
    public required uint AttributeCount;
    public required uint VertexStride;
}
