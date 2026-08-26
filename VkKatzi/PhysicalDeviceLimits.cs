using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceLimits
{
    public uint MaxImageDimension1D;
    public uint MaxImageDimension2D;
    public uint MaxImageDimension3D;
    public uint MaxImageDimensionCube;
    public uint MaxImageArrayLayers;
    public uint MaxTexelBufferElements;
    public uint MaxUniformBufferRange;
    public uint MaxStorageBufferRange;
    public uint MaxPushConstantsSize;
    public uint MaxMemoryAllocationCount;
    public uint MaxSamplerAllocationCount;
    public ulong BufferImageGranularity;
    public ulong SparseAddressSpaceSize;
    public uint MaxBoundDescriptorSets;
    public uint MaxPerStageDescriptorSamplers;
    public uint MaxPerStageDescriptorUniformBuffers;
    public uint MaxPerStageDescriptorStorageBuffers;
    public uint MaxPerStageDescriptorSampledImages;
    public uint MaxPerStageDescriptorStorageImages;
    public uint MaxPerStageDescriptorInputAttachments;
    public uint MaxPerStageResources;
    public uint MaxDescriptorSetSamplers;
    public uint MaxDescriptorSetUniformBuffers;
    public uint MaxDescriptorSetUniformBuffersDynamic;
    public uint MaxDescriptorSetStorageBuffers;
    public uint MaxDescriptorSetStorageBuffersDynamic;
    public uint MaxDescriptorSetSampledImages;
    public uint MaxDescriptorSetStorageImages;
    public uint MaxDescriptorSetInputAttachments;
    public uint MaxVertexInputAttributes;
    public uint MaxVertexInputBindings;
    public uint MaxVertexInputAttributeOffset;
    public uint MaxVertexInputBindingStride;
    public uint MaxVertexOutputComponents;
    public uint MaxTessellationGenerationLevel;
    public uint MaxTessellationPatchSize;
    public uint MaxTessellationControlPerVertexInputComponents;
    public uint MaxTessellationControlPerVertexOutputComponents;
    public uint MaxTessellationControlPerPatchOutputComponents;
    public uint MaxTessellationControlTotalOutputComponents;
    public uint MaxTessellationEvaluationInputComponents;
    public uint MaxTessellationEvaluationOutputComponents;
    public uint MaxGeometryShaderInvocations;
    public uint MaxGeometryInputComponents;
    public uint MaxGeometryOutputComponents;
    public uint MaxGeometryOutputVertices;
    public uint MaxGeometryTotalOutputComponents;
    public uint MaxFragmentInputComponents;
    public uint MaxFragmentOutputAttachments;
    public uint MaxFragmentDualSrcAttachments;
    public uint MaxFragmentCombinedOutputResources;
    public uint MaxComputeSharedMemorySize;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public uint[] MaxComputeWorkGroupCount;
    public uint MaxComputeWorkGroupInvocations;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public uint[] MaxComputeWorkGroupSize;
    public uint SubPixelPrecisionBits;
    public uint SubTexelPrecisionBits;
    public uint MipmapPrecisionBits;
    public uint MaxDrawIndexedIndexValue;
    public uint MaxDrawIndirectCount;
    public float MaxSamplerLodBias;
    public float MaxSamplerAnisotropy;
    public uint MaxViewports;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] MaxViewportDimensions;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public float[] ViewportBoundsRange;
    public uint ViewportSubPixelBits;
    public nuint MinMemoryMapAlignment;
    public ulong MinTexelBufferOffsetAlignment;
    public ulong MinUniformBufferOffsetAlignment;
    public ulong MinStorageBufferOffsetAlignment;
    public int MinTexelOffset;
    public uint MaxTexelOffset;
    public int MinTexelGatherOffset;
    public uint MaxTexelGatherOffset;
    public float MinInterpolationOffset;
    public float MaxInterpolationOffset;
    public uint SubPixelInterpolationOffsetBits;
    public uint MaxFramebufferWidth;
    public uint MaxFramebufferHeight;
    public uint MaxFramebufferLayers;
    public uint FramebufferColorSampleCounts;
    public uint FramebufferDepthSampleCounts;
    public uint FramebufferStencilSampleCounts;
    public uint FramebufferNoAttachmentsSampleCounts;
    public uint MaxColorAttachments;
    public uint SampledImageColorSampleCounts;
    public uint SampledImageIntegerSampleCounts;
    public uint SampledImageDepthSampleCounts;
    public uint SampledImageStencilSampleCounts;
    public uint StorageImageSampleCounts;
    public uint MaxSampleMaskWords;
    public byte TimestampComputeAndGraphics;
    public float TimestampPeriod;
    public uint MaxClipDistances;
    public uint MaxCullDistances;
    public uint MaxCombinedClipAndCullDistances;
    public uint DiscreteQueuePriorities;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public float[] PointSizeRange;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public float[] LineWidthRange;
    public float PointSizeGranularity;
    public float LineWidthGranularity;
    public byte StrictLines;
    public byte StandardSampleLocations;
    public ulong OptimalBufferCopyOffsetAlignment;
    public ulong OptimalBufferCopyRowPitchAlignment;
    public ulong NonCoherentAtomSize; 
}