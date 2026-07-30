using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct ShaderPaths
{
    [MarshalAs(UnmanagedType.LPStr)]
    public string VertexShaderPath;
    
    [MarshalAs(UnmanagedType.LPStr)]
    public string FragmentShaderPath;
}