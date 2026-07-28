using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VkKatzi;

public static class VKK
{
    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateWindow")]
    public static extern Window CreateWindow(int width, int height, string title);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WindowShouldClose")]
    public static extern bool WindowShouldClose(Window window);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_GetTime")]
    public static extern double GetTime();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_GetFramebufferSize")]
    public static extern void GetFramebufferSize(Window window, out int width, out int height);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_GetMouseButton")]
    public static extern int GetMouseButton(Window window, int button);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_GetCursorPosition")]
    public static extern void GetCursorPosition(Window window, out double x, out double y);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitDevice")]
    public static extern PhysicalDeviceInfo InitDevice(Window window, VkKatziConfig config);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitPipeline")]
    public static extern bool InitPipeline(PushConstantRange pushConstantRange);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_Present")]
    public static extern void Present();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_End")]
    public static extern void End();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_TerminateWindowing")]
    public static extern void TerminateWindowing();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_PollEvents")]
    public static extern void PollEvents();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateBuffer")]
    public static extern Buffer CreateBuffer(nuint size, BufferUsage usage);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateUniform")]
    public static extern Uniform CreateUniform(uint binding, nuint size, ShaderStage shaderStage);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyBuffer")]
    public static extern void DestroyBuffer(Buffer buffer);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyUniform")]
    public static extern void DestroyUniform(Uniform uniform);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WriteBuffer")]
    private static extern unsafe void VKK_WriteBuffer(Buffer buffer, void* data, nuint size, nuint offset);

    public static unsafe void WriteBuffer<T>(Buffer buffer, T[] data, nuint offset = 0) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_WriteBuffer(buffer, ptr, (nuint)(sizeof(T) * data.Length), offset);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WriteUniform")]
    private static extern unsafe void VKK_WriteUniform(Uniform uniform, void* data, nuint size, nuint offset);

    public static unsafe void WriteUniform<T>(Uniform uniform, T[] data, nuint offset = 0) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_WriteUniform(uniform, ptr, (nuint)(sizeof(T) * data.Length), offset);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_Draw")]
    public static extern void Draw(Buffer vertexBuffer, uint vertexCount, Buffer indexBuffer, uint indexCount);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_SetPushConstantData")]
    private static extern unsafe void VKK_SetPushConstantData(void* data);

    public static unsafe void SetPushConstantData<T>(T[] data) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_SetPushConstantData(ptr);
        }
    }
}
