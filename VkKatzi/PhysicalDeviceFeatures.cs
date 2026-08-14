using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceFeatures
{
    public readonly bool RobustBufferAccess;
    public readonly bool FullDrawIndexUint32;
    public readonly bool ImageCubeArray;
    public readonly bool IndependentBlend;
    public readonly bool GeometryShader;
    public readonly bool TessellationShader;
    public readonly bool SampleRateShading;
    public readonly bool DualSrcBlend;
    public readonly bool LogicOp;
    public readonly bool MultiDrawIndirect;
    public readonly bool DrawIndirectFirstInstance;
    public readonly bool DepthClamp;
    public readonly bool DepthBiasClamp;
    public readonly bool FillModeNonSolid;
    public readonly bool DepthBounds;
    public readonly bool WideLines;
    public readonly bool LargePoints;
    public readonly bool AlphaToOne;
    public readonly bool MultiViewport;
    public readonly bool SamplerAnisotropy;
    public readonly bool TextureCompressionETC2;
    public readonly bool TextureCompressionASTC_LDR;
    public readonly bool TextureCompressionBC;
    public readonly bool OcclusionQueryPrecise;
    public readonly bool PipelineStatisticsQuery;
    public readonly bool VertexPipelineStoresAndAtomics;
    public readonly bool FragmentStoresAndAtomics;
    public readonly bool ShaderTessellationAndGeometryPointSize;
    public readonly bool ShaderImageGatherExtended;
    public readonly bool ShaderStorageImageExtendedFormats;
    public readonly bool ShaderStorageImageMultisample;
    public readonly bool ShaderStorageImageReadWithoutFormat;
    public readonly bool ShaderStorageImageWriteWithoutFormat;
    public readonly bool ShaderUniformBufferArrayDynamicIndexing;
    public readonly bool ShaderSampledImageArrayDynamicIndexing;
    public readonly bool ShaderStorageBufferArrayDynamicIndexing;
    public readonly bool ShaderStorageImageArrayDynamicIndexing;
    public readonly bool ShaderClipDistance;
    public readonly bool ShaderCullDistance;
    public readonly bool ShaderFloat64;
    public readonly bool ShaderInt64;
    public readonly bool ShaderInt16;
    public readonly bool ShaderResourceResidency;
    public readonly bool ShaderResourceMinLod;
    public readonly bool SparseBinding;
    public readonly bool SparseResidencyBuffer;
    public readonly bool SparseResidencyImage2D;
    public readonly bool SparseResidencyImage3D;
    public readonly bool SparseResidency2Samples;
    public readonly bool SparseResidency4Samples;
    public readonly bool SparseResidency8Samples;
    public readonly bool SparseResidency16Samples;
    public readonly bool SparseResidencyAliased;
    public readonly bool VariableMultisampleRate;
    public readonly bool InheritedQueries;
}