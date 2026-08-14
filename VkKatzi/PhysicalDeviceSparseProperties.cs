using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceSparseProperties
{
    public readonly bool ResidencyStandard2DBlockShape;
    public readonly bool ResidencyStandard2DMultisampleBlockShape;
    public readonly bool ResidencyStandard3DBlockShape;
    public readonly bool ResidencyAlignedMipSize;
    public readonly bool ResidencyNonResidentStrict;
}