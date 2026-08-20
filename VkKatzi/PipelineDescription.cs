using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PipelineDescription
{
    public string VertexShaderPath;
    public string FragmentShaderPath;

    public VertexAttribute[] VertexAttributes;
    public uint AttributeCount;
    public uint VertexStride;

    public uint InstanceStride;
    public VertexAttribute[] InstanceAttributes;
    public uint InstanceAttributeCount;

    public Rasterizer Rasterizer;
    public bool EnableDepthTesting;
}
