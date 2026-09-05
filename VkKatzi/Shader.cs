using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
public struct Shader
{
    internal Internal_Shader InternalShader;
}