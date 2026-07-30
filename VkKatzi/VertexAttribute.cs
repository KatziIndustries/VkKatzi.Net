using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct VertexAttribute
{
    public required uint Location;
    public required VertexFormat Format;
    public required uint Offset;
}