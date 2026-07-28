using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PushConstantRange
{
    public required ShaderStage ShaderStage;
    public required uint Offset;
    public required uint Size;
}