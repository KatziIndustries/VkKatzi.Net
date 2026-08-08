using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct DescriptorSetLayoutBinding
{
    public required uint Binding;
    public required DescriptorType DescriptorType;
    public required ShaderStage ShaderStage;
}