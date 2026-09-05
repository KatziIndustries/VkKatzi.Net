using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PipelineDescription
{
    public Shader VertexShader;
    public Shader FragmentShader;

    public VertexAttribute[] VertexAttributes;
    public uint AttributeCount;
    public uint VertexStride;

    public uint InstanceStride;
    public VertexAttribute[] InstanceAttributes;
    public uint InstanceAttributeCount;

    public Rasterizer Rasterizer;
    public bool EnableDepthTesting;
    public CompareOp DepthCompareOp;

    public bool EnableBlending;
    public BlendOp ColorBlendOp;
    public BlendOp AlphaBlendOp;

    public PrimitiveTopology PrimitiveTopology;
}
