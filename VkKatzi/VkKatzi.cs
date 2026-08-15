using System.Drawing;
using System.Runtime.InteropServices;

namespace VkKatzi;

public static class VKK
{
    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_EnumeratePhysicalDevices")]
    public static extern uint EnumeratePhysicalDevices(PhysicalDeviceInfo[] devices, uint maxDevices);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitInstance")]
    internal static extern Result VKK_InitInstance(Internal_VKKConfig config, out InstanceInfo instanceInfo);

    public static Result InitInstance(VKKConfig config, out InstanceInfo instanceInfo)
    {
        IntPtr[] strPointers = new nint[config.RequiredExtensions.Length];

        for (int i = 0; i < config.RequiredExtensions.Length; i++)
        {
            strPointers[i] = Marshal.StringToHGlobalAnsi(config.RequiredExtensions[i]);
        }

        IntPtr arrayPtr = Marshal.AllocHGlobal(IntPtr.Size * strPointers.Length);
        Marshal.Copy(strPointers, 0, arrayPtr, strPointers.Length);

        Internal_VKKConfig internalConfig = new()
        {
            PresentMode = config.PresentMode,
            ImageBufferSize = config.ImageBufferSize,
            EnableValidationLayers = config.EnableValidationLayers,
            LogWarnings = config.LogWarnings,
            RequiredExtensions = arrayPtr,
            RequiredExtensionsCount = config.RequiredExtensionsCount
        };

        Result result = VKK_InitInstance(internalConfig, out instanceInfo);

        foreach (IntPtr ptr in strPointers)
        {
            Marshal.FreeHGlobal(ptr);
        }

        Marshal.FreeHGlobal(arrayPtr);

        return result;
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitDevice")]
    public static extern Result InitDevice(uint deviceIndex, out PhysicalDeviceInfo deviceInfo);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_InitRenderer")]
    public static extern Result InitRenderer(RendererConfig rendererConfig);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_Present")]
    internal static extern void VKK_Present(VKK_Color color);

    public static void Present(Color color)
    {
        VKK_Color clearColor = new() { R = color.R / 255, G = color.G / 255, B = color.B / 255, A = color.A / 255 };
        VKK_Present(clearColor);
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_End")]
    public static extern void End();

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateBuffer")]
    public static extern BufferHandle CreateBuffer(nuint size, BufferUsage usage);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateUniform")]
    public static extern UniformHandle CreateUniform(nuint size, ShaderStage shaderStage);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_BindUniform")]
    public static extern void BindUniform(uint binding, UniformHandle uniform);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_SetTextureSampler")]
    public static extern void SetTextureSampler(TextureHandle texture, SamplerInfo samplerInfo);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_GetTextureSize")]
    public static extern void GetTextureSize(TextureHandle texture, out uint width, out uint height);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateTexture")]
    public static extern TextureHandle CreateTexture(string path, ImageFormat textureFormat);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateTextureFromPixels")]
    internal static unsafe extern TextureHandle VKK_CreateTextureFromPixels(void* data, uint width, uint height, ImageFormat textureFormat);

    public static unsafe void CreateTextureFromPixels<T>(T[] pixels, uint width, uint height, ImageFormat textureFormat) where T : unmanaged
    {
        fixed (T* ptr = pixels)
        {
            VKK_CreateTextureFromPixels(ptr, width, height, textureFormat);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_BindTexture")]
    public static extern void BindTexture(uint binding, TextureHandle texture);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyBuffer")]
    public static extern void DestroyBuffer(BufferHandle buffer);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyTexture")]
    public static extern void DestroyTexture(TextureHandle texture);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyUniform")]
    public static extern void DestroyUniform(UniformHandle uniform);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DestroyPipeline")]
    public static extern void DestroyPipeline(PipelineHandle uniform);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WriteBuffer")]
    internal static extern unsafe void VKK_WriteBuffer(BufferHandle buffer, void* data, nuint size, nuint offset);

    public static unsafe void WriteBuffer<T>(BufferHandle buffer, T[] data, nuint offset = 0) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_WriteBuffer(buffer, ptr, (nuint)(sizeof(T) * data.Length), offset);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_WriteUniform")]
    internal static extern unsafe void VKK_WriteUniform(UniformHandle uniform, void* data, nuint size, nuint offset);

    public static unsafe void WriteUniform<T>(UniformHandle uniform, T[] data, nuint offset = 0) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_WriteUniform(uniform, ptr, (nuint)(sizeof(T) * data.Length), offset);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_Draw")]
    public static extern void Draw(PipelineHandle pipeline, BufferHandle vertexBuffer, uint vertexCount, BufferHandle indexBuffer, uint indexCount);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_DrawInstanced")]
    public static extern void DrawInstanced(PipelineHandle pipeline, BufferHandle vertexBuffer, uint vertexCount, BufferHandle indexBuffer, uint indexCount, BufferHandle instanceBuffer, uint instanceCount);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_SetPushConstantData")]
    internal static extern unsafe void VKK_SetPushConstantData(void* data);

    public static unsafe void SetPushConstantData<T>(T[] data) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            VKK_SetPushConstantData(ptr);
        }
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreatePipeline")]
    internal static extern PipelineHandle VKK_CreatePipeline(Internal_PipelineDescription pipelineDescription);

    public static PipelineHandle CreatePipeline(PipelineDescription pipelineDescription)
    {
        Internal_PipelineDescription desc = new()
        {
            VertexShaderPath = pipelineDescription.VertexShaderPath,
            FragmentShaderPath = pipelineDescription.FragmentShaderPath,
            AttributeCount = pipelineDescription.AttributeCount,
            VertexStride = pipelineDescription.VertexStride,
            InstanceStride = pipelineDescription.InstanceStride,
            InstanceAttributeCount = pipelineDescription.InstanceAttributeCount
        };

        if (pipelineDescription.AttributeCount > 0)
        {
            unsafe
            {
                fixed (VertexAttribute* ptr = pipelineDescription.VertexAttributes)
                desc.VertexAttributes = ptr;
            }
        }

        if (pipelineDescription.InstanceAttributeCount > 0)
        {
            unsafe
            {
                fixed (VertexAttribute* ptr = pipelineDescription.InstanceAttributes)
                desc.InstanceAttributes = ptr;
            }
        }

        return VKK_CreatePipeline(desc);
    }

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_SetSurface")]
    public static extern void SetSurface(SurfaceHandle surface, uint width, uint height);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_SetFramebufferSize")]
    public static extern void SetFramebufferSize(uint width, uint height);

    [DllImport("vkkatzi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VKK_CreateDescriptorSetLayout")]
    public static extern Result CreateDescriptorSetLayout(DescriptorSetLayoutBinding[] bindings, uint bindingsCount);
}
