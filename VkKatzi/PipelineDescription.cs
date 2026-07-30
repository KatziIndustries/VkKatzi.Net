using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PipelineDescription
{
    public required ShaderPaths ShaderPaths;
    public required VertexAttribute* VertexAttributes;
    public required uint AttributeCount;
    public required uint VertexStride;
}
