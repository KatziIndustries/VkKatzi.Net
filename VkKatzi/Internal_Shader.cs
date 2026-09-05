using System.Runtime.InteropServices;

namespace VkKatzi;

[StructLayout(LayoutKind.Sequential)]
internal struct Internal_Shader
{
    public IntPtr Code;
    public nuint CodeSize;
}