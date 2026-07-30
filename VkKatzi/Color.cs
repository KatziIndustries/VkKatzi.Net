using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
internal struct VKK_Color
{
    public required float R;
    public required float G;
    public required float B;
    public required float A;
}