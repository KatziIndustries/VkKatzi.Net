using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct RendererConfig
{
    public PushConstantRange PushConstantRange;
    public uint MaxDescriptorSets;
}