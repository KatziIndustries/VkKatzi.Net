using System.Runtime.InteropServices;

namespace VkKatzi;

/// <summary>
/// The variables of this struct are all bytes because C# booleans are not 1 byte large like in C so we have to use this workaround
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceFeatures
{
    public byte RobustBufferAccess;
    public byte FullDrawIndexUint32;
    public byte ImageCubeArray;
    public byte IndependentBlend;
    public byte GeometryShader;
    public byte TessellationShader;
    public byte SampleRateShading;
    public byte DualSrcBlend;
    public byte LogicOp;
    public byte MultiDrawIndirect;
    public byte DrawIndirectFirstInstance;
    public byte DepthClamp;
    public byte DepthBiasClamp;
    public byte FillModeNonSolid;
    public byte DepthBounds;
    public byte WideLines;
    public byte LargePoints;
    public byte AlphaToOne;
    public byte MultiViewport;
    public byte SamplerAnisotropy;
    public byte TextureCompressionETC2;
    public byte TextureCompressionASTC_LDR;
    public byte TextureCompressionBC;
    public byte OcclusionQueryPrecise;
    public byte PipelineStatisticsQuery;
    public byte VertexPipelineStoresAndAtomics;
    public byte FragmentStoresAndAtomics;
    public byte ShaderTessellationAndGeometryPointSize;
    public byte ShaderImageGatherExtended;
    public byte ShaderStorageImageExtendedFormats;
    public byte ShaderStorageImageMultisample;
    public byte ShaderStorageImageReadWithoutFormat;
    public byte ShaderStorageImageWriteWithoutFormat;
    public byte ShaderUniformBufferArrayDynamicIndexing;
    public byte ShaderSampledImageArrayDynamicIndexing;
    public byte ShaderStorageBufferArrayDynamicIndexing;
    public byte ShaderStorageImageArrayDynamicIndexing;
    public byte ShaderClipDistance;
    public byte ShaderCullDistance;
    public byte ShaderFloat64;
    public byte ShaderInt64;
    public byte ShaderInt16;
    public byte ShaderResourceResidency;
    public byte ShaderResourceMinLod;
    public byte SparseBinding;
    public byte SparseResidencyBuffer;
    public byte SparseResidencyImage2D;
    public byte SparseResidencyImage3D;
    public byte SparseResidency2Samples;
    public byte SparseResidency4Samples;
    public byte SparseResidency8Samples;
    public byte SparseResidency16Samples;
    public byte SparseResidencyAliased;
    public byte VariableMultisampleRate;
    public byte InheritedQueries;
}