using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceInfo
{
    public readonly PhysicalDeviceProperties Properties;
    public readonly PhysicalDeviceFeatures Features;
}