using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceInfo
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
    public string Name;

    public uint ApiVersion;
    public uint DriverVersion;
    public uint DeviceId;
    public uint VendorId;
    public PhysicalDeviceType DeviceType;
}