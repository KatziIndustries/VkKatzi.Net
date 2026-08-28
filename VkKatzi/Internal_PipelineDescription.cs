using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct Internal_PipelineDescription
{
    public string VertexShaderPath;
    public string FragmentShaderPath;

    public VertexAttribute* VertexAttributes;
    public uint AttributeCount;
    public uint VertexStride;

    public uint InstanceStride;
    public VertexAttribute* InstanceAttributes;
    public uint InstanceAttributeCount;

    public Rasterizer Rasterizer;
    public bool EnableDepthTesting;
    public CompareOp DepthCompareOp;

    public bool EnableBlending;
    public BlendOp ColorBlendOp;
    public BlendOp AlphaBlendOp;

    public PrimitiveTopology PrimitiveTopology;
}
