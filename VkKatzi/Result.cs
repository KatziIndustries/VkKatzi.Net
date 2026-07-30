namespace VkKatzi;

public enum Result
{
    Success = 0,
    InstanceCreationFailed,
    SurfaceCreationFailed,
    NoSuitableDevice,
    InvalidDeviceIndex,
    DeviceCreationFailed,
    SwapchainCreationFailed,
    RenderPassCreationFailed,
    DescriptorSetLayoutCreationFailed,
    FramebufferCreationFailed,
    CommandPoolCreationFailed,
    CommandBufferCreationFailed,
    SyncObjectsCreationFailed,
    DescriptorPoolCreationFailed
}