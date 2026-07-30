using System.Drawing;
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

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_EnumeratePhysicalDevices")]
    public static extern uint EnumeratePhysicalDevices(PhysicalDeviceInfo[] devices, uint maxDevices);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitInstance")]
    public static extern Result InitInstance(Window window, VkKatziConfig config, out InstanceInfo instanceInfo);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitDevice")]
    public static extern Result InitDevice(uint deviceIndex, out PhysicalDeviceInfo deviceInfo);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitPipeline")]
    public static extern Result InitPipeline(PushConstantRange pushConstantRange);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_Present")]
    private static extern void VKK_Present(VKK_Color color);

    public static void Present(Color color)
    {
        VKK_Color clearColor = new() { R = color.R / 255, G = color.G / 255, B = color.B / 255, A = color.A / 255 };
        VKK_Present(clearColor);
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_End")]
    public static extern void End();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_TerminateWindowing")]
    public static extern void TerminateWindowing();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_PollEvents")]
    public static extern void PollEvents();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateBuffer")]
    public static extern BufferHandle CreateBuffer(nuint size, BufferUsage usage);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateUniform")]
    public static extern UniformHandle CreateUniform(uint binding, nuint size, ShaderStage shaderStage);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyBuffer")]
    public static extern void DestroyBuffer(BufferHandle buffer);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyUniform")]
    public static extern void DestroyUniform(UniformHandle uniform);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyPipeline")]
    public static extern void DestroyPipeline(PipelineHandle uniform);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WriteBuffer")]
    private static extern unsafe void VKK_WriteBuffer(BufferHandle buffer, void* data, nuint size, nuint offset);

    public static unsafe void WriteBuffer<T>(BufferHandle buffer, T[] data, nuint offset = 0) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_WriteBuffer(buffer, ptr, (nuint)(sizeof(T) * data.Length), offset);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WriteUniform")]
    private static extern unsafe void VKK_WriteUniform(UniformHandle uniform, void* data, nuint size, nuint offset);

    public static unsafe void WriteUniform<T>(UniformHandle uniform, T[] data, nuint offset = 0) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_WriteUniform(uniform, ptr, (nuint)(sizeof(T) * data.Length), offset);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_Draw")]
    public static extern void Draw(PipelineHandle pipeline, BufferHandle vertexBuffer, uint vertexCount, BufferHandle indexBuffer, uint indexCount);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_SetPushConstantData")]
    private static extern unsafe void VKK_SetPushConstantData(void* data);

    public static unsafe void SetPushConstantData<T>(T[] data) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_SetPushConstantData(ptr);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreatePipeline")]
    public static extern PipelineHandle CreatePipeline(PipelineDescription pipelineDescription);
}
