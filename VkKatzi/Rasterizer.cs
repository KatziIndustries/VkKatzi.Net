using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct Rasterizer
{
    public PolygonMode PolygonMode;
    public CullMode CullMode;
    public FrontFace FrontFace;
    public float LineWidth;
}