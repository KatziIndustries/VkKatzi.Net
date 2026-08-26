using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceInfo
{
    public PhysicalDeviceProperties Properties;
    public PhysicalDeviceFeatures Features;
}
