using System.Runtime.InteropServices;

namespace VkKatzi.SDL3;

public static class VKK_SDL
{
    [DllImport("vkkatzi_SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateSurfaceSDL")]
    public static extern Result CreateSurface(IntPtr window, InstanceHandle instance, out SurfaceHandle surface);
}