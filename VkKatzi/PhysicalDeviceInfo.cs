using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceInfo
{
    public bool Success;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string Name;

    public uint ApiVersion;
    public uint DriverVersion;
    public uint DeviceId;
    public PhysicalDeviceType DeviceType;
    public uint VendorId;
}