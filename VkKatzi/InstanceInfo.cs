using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct InstanceInfo
{
    public uint VersionMajor;
    public uint VersionMinor;
    public uint VersionPatch;
    public InstanceHandle Instance;
}