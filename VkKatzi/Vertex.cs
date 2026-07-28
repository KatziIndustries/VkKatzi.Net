using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct Vertex
{
    public float X;
    public float Y;

    public float R;
    public float G;
    public float B;
    public float A;
}