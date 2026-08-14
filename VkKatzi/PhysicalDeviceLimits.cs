using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceLimits
{
    public readonly uint MaxImageDimension1D;
    public readonly uint MaxImageDimension2D;
    public readonly uint MaxImageDimension3D;
    public readonly uint MaxImageDimensionCube;
    public readonly uint MaxImageArrayLayers;
    public readonly uint MaxTexelBufferElements;
    public readonly uint MaxUniformBufferRange;
    public readonly uint MaxStorageBufferRange;
    public readonly uint MaxPushConstantsSize;
    public readonly uint MaxMemoryAllocationCount;
    public readonly uint MaxSamplerAllocationCount;
    public readonly ulong BufferImageGranularity;
    public readonly ulong SparseAddressSpaceSize;
    public readonly uint MaxBoundDescriptorSets;
    public readonly uint MaxPerStageDescriptorSamplers;
    public readonly uint MaxPerStageDescriptorUniformBuffers;
    public readonly uint MaxPerStageDescriptorStorageBuffers;
    public readonly uint MaxPerStageDescriptorSampledImages;
    public readonly uint MaxPerStageDescriptorStorageImages;
    public readonly uint MaxPerStageDescriptorInputAttachments;
    public readonly uint MaxPerStageResources;
    public readonly uint MaxDescriptorSetSamplers;
    public readonly uint MaxDescriptorSetUniformBuffers;
    public readonly uint MaxDescriptorSetUniformBuffersDynamic;
    public readonly uint MaxDescriptorSetStorageBuffers;
    public readonly uint MaxDescriptorSetStorageBuffersDynamic;
    public readonly uint MaxDescriptorSetSampledImages;
    public readonly uint MaxDescriptorSetStorageImages;
    public readonly uint MaxDescriptorSetInputAttachments;
    public readonly uint MaxVertexInputAttributes;
    public readonly uint MaxVertexInputBindings;
    public readonly uint MaxVertexInputAttributeOffset;
    public readonly uint MaxVertexInputBindingStride;
    public readonly uint MaxVertexOutputComponents;
    public readonly uint MaxTessellationGenerationLevel;
    public readonly uint MaxTessellationPatchSize;
    public readonly uint MaxTessellationControlPerVertexInputComponents;
    public readonly uint MaxTessellationControlPerVertexOutputComponents;
    public readonly uint MaxTessellationControlPerPatchOutputComponents;
    public readonly uint MaxTessellationControlTotalOutputComponents;
    public readonly uint MaxTessellationEvaluationInputComponents;
    public readonly uint MaxTessellationEvaluationOutputComponents;
    public readonly uint MaxGeometryShaderInvocations;
    public readonly uint MaxGeometryInputComponents;
    public readonly uint MaxGeometryOutputComponents;
    public readonly uint MaxGeometryOutputVertices;
    public readonly uint MaxGeometryTotalOutputComponents;
    public readonly uint MaxFragmentInputComponents;
    public readonly uint MaxFragmentOutputAttachments;
    public readonly uint MaxFragmentDualSrcAttachments;
    public readonly uint MaxFragmentCombinedOutputResources;
    public readonly uint MaxComputeSharedMemorySize;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public readonly uint[] MaxComputeWorkGroupCount;
    public readonly uint MaxComputeWorkGroupInvocations;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public readonly uint[] MaxComputeWorkGroupSize;
    public readonly uint SubPixelPrecisionBits;
    public readonly uint SubTexelPrecisionBits;
    public readonly uint MipmapPrecisionBits;
    public readonly uint MaxDrawIndexedIndexValue;
    public readonly uint MaxDrawIndirectCount;
    public readonly float MaxSamplerLodBias;
    public readonly float MaxSamplerAnisotropy;
    public readonly uint MaxViewports;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public readonly uint[] MaxViewportDimensions;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public readonly float[] ViewportBoundsRange;
    public readonly uint ViewportSubPixelBits;
    public readonly nuint MinMemoryMapAlignment;
    public readonly ulong MinTexelBufferOffsetAlignment;
    public readonly ulong MinUniformBufferOffsetAlignment;
    public readonly ulong MinStorageBufferOffsetAlignment;
    public readonly int MinTexelOffset;
    public readonly uint MaxTexelOffset;
    public readonly int MinTexelGatherOffset;
    public readonly uint MaxTexelGatherOffset;
    public readonly float MinInterpolationOffset;
    public readonly float MaxInterpolationOffset;
    public readonly uint SubPixelInterpolationOffsetBits;
    public readonly uint MaxFramebufferWidth;
    public readonly uint MaxFramebufferHeight;
    public readonly uint MaxFramebufferLayers;
    public readonly uint FramebufferColorSampleCounts;
    public readonly uint FramebufferDepthSampleCounts;
    public readonly uint FramebufferStencilSampleCounts;
    public readonly uint FramebufferNoAttachmentsSampleCounts;
    public readonly uint MaxColorAttachments;
    public readonly uint SampledImageColorSampleCounts;
    public readonly uint SampledImageIntegerSampleCounts;
    public readonly uint SampledImageDepthSampleCounts;
    public readonly uint SampledImageStencilSampleCounts;
    public readonly uint StorageImageSampleCounts;
    public readonly uint MaxSampleMaskWords;
    public readonly bool TimestampComputeAndGraphics;
    public readonly float TimestampPeriod;
    public readonly uint MaxClipDistances;
    public readonly uint MaxCullDistances;
    public readonly uint MaxCombinedClipAndCullDistances;
    public readonly uint DiscreteQueuePriorities;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public readonly float[] PointSizeRange;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public readonly float[] LineWidthRange;
    public readonly float PointSizeGranularity;
    public readonly float LineWidthGranularity;
    public readonly bool StrictLines;
    public readonly bool StandardSampleLocations;
    public readonly ulong OptimalBufferCopyOffsetAlignment;
    public readonly ulong OptimalBufferCopyRowPitchAlignment;
    public readonly ulong NonCoherentAtomSize; 
}