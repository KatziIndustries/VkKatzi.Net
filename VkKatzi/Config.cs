using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct VkKatziConfig
{
    public required PresentMode PresentMode;
    public required uint ImageBufferSize;
    public bool EnableValidationLayers;
    public bool LogWarnings;
}