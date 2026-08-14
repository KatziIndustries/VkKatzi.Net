using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct SamplerInfo
{
    public SamplerFilter Filter;
    public SamplerAddressMode AddressMode;
    public SamplerBorderColor BorderColor;
}