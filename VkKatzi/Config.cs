using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct VKKConfig
{
    public required PresentMode PresentMode;
    public required uint ImageBufferSize;
    public bool EnableValidationLayers;
    public bool LogWarnings;

    public required string[] RequiredExtensions;
    public required uint RequiredExtensionsCount;
}

internal struct Internal_VKKConfig
{
    public required PresentMode PresentMode;
    public required uint ImageBufferSize;
    public bool EnableValidationLayers;
    public bool LogWarnings;

    public required IntPtr RequiredExtensions;
    public required uint RequiredExtensionsCount;
}