using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct PhysicalDeviceProperties
{

    public uint ApiVersion;
    public uint DriverVersion;
    public uint VendorId;
    public uint DeviceId;
    public PhysicalDeviceType DeviceType;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string DeviceName;

    public PhysicalDeviceLimits Limits;
    public PhysicalDeviceSparseProperties SparseProperties;
}