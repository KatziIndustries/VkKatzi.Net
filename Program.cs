using System.Drawing;
using System.Runtime.InteropServices;
using VkKatzi;

internal static class Program
{
    private static Vertex[] _verticesLeft =
    {
        new() { X = 0.5f, Y = -1.0f, R = 1.0f, A = 1.0f },
        new() { X = 1.0f, Y = 1.0f, G = 1.0f, A = 1.0f },
        new() { X = 0.0f, Y = 1.0f, B = 1.0f, A = 1.0f },
    };

    private static Vertex[] _verticesRight =
    {
        new() { X = -0.5f, Y = -1.0f, R = 1.0f, A = 1.0f },
        new() { X = 0.0f, Y = 1.0f, G = 1.0f, A = 1.0f },
        new() { X = -1.0f, Y = 1.0f, B = 1.0f, A = 1.0f },
    };

    private static ushort[] indices =
    {
        0, 1, 2
    };

    private static void Main(string[] args)
    {
        nint window = VKK.CreateWindow(800, 600, "Katzi lel");

        VkKatziConfig config = new()
        {
            PresentMode = PresentMode.Mailbox,
            ImageBufferSize = 3,
            EnableValidationLayers = true,
            LogWarnings = true
        };

        InstanceInfo instanceInfo;
        if (VKK.InitInstance(window, config, out instanceInfo) != Result.Success)
            throw new Exception("Failed to initialize Instance");

        Console.WriteLine($"Using Vulkan version {instanceInfo.VersionMajor}.{instanceInfo.VersionMinor}.{instanceInfo.VersionPatch}");

        PhysicalDeviceInfo[] devices = new PhysicalDeviceInfo[8];
        uint deviceCount = VKK.EnumeratePhysicalDevices(devices, 8);

        for (int i = 0; i < deviceCount; i++)
        {
            Console.WriteLine($"[Device #{i}] {devices[i].Name}");
        }


        PhysicalDeviceInfo deviceInfo;
        if (VKK.InitDevice(0, out deviceInfo) != Result.Success)
            throw new Exception("Failed to initialize device");

        Console.WriteLine($"[GPU] Name: {deviceInfo.Name}, Type: {Enum.GetName(deviceInfo.DeviceType)}");

        UniformHandle timeUniform = VKK.CreateUniform(0, sizeof(float), ShaderStage.Vertex);

        PushConstantRange pushConstantRange = new()
        {
            ShaderStage = ShaderStage.All,
            Offset = 0,
            Size = sizeof(float) * 18
        };

        if (VKK.InitPipeline(pushConstantRange) != Result.Success)
            throw new Exception("Failed to initialize Pipeline");
        

        VertexAttribute[] attributes =
        {
            new() { Location = 0, Format = VertexFormat.Float2, Offset = (uint)Marshal.OffsetOf<Vertex>("X")},
            new() { Location = 1, Format = VertexFormat.Float4, Offset = (uint)Marshal.OffsetOf<Vertex>("R")}
        };


        PipelineDescription pipelineDescription;
        PipelineDescription solidPipelineDescription;

        unsafe
        {
            fixed (VertexAttribute* ptr = attributes)
            {
                pipelineDescription = new()
                {
                    ShaderPaths = new() { VertexShaderPath = "shader/compiled/vert.spv", FragmentShaderPath = "shader/compiled/frag.spv" },
                    VertexAttributes = ptr,
                    AttributeCount = 2,
                    VertexStride = (uint)Marshal.SizeOf<Vertex>()
                };

                solidPipelineDescription = new()
                {
                    ShaderPaths = new() { VertexShaderPath = "shader/compiled/vert.spv", FragmentShaderPath = "shader/compiled/fragSolid.spv" },
                    VertexAttributes = ptr,
                    AttributeCount = 2,
                    VertexStride = (uint)Marshal.SizeOf<Vertex>()
                };
            }
        }

        PipelineHandle pipeline = VKK.CreatePipeline(pipelineDescription);
        PipelineHandle solidPipeline = VKK.CreatePipeline(solidPipelineDescription);

        BufferHandle vertexBuffer = VKK.CreateBuffer((nuint)Marshal.SizeOf<Vertex>() * 3, BufferUsage.Vertex);
        VKK.WriteBuffer(vertexBuffer, _verticesLeft);

        BufferHandle solidVertexBuffer = VKK.CreateBuffer((nuint)Marshal.SizeOf<Vertex>() * 3, BufferUsage.Vertex);
        VKK.WriteBuffer(solidVertexBuffer, _verticesRight);

        BufferHandle indexBuffer = VKK.CreateBuffer((nuint)Marshal.SizeOf<ushort>() * 3, BufferUsage.Index);
        VKK.WriteBuffer(indexBuffer, indices);

        float elapsedTime = 0;
        float frameTimeTimer = 0;

        double lastFrameTime = VKK.GetTime();

        while (!VKK.WindowShouldClose(window))
        {
            double currentTime = VKK.GetTime();
            double deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;

            elapsedTime += (float)deltaTime;
            frameTimeTimer += (float)deltaTime;

            if (frameTimeTimer >= 1)
            {
                Console.WriteLine($"Frametime: {(float)deltaTime}, FPS: {1.0f / (float)deltaTime}");
                frameTimeTimer = 0;
            }

            double cursorX, cursorY;
            VKK.GetCursorPosition(window, out cursorX, out cursorY);

            VKK.GetFramebufferSize(window, out int windowWidth, out int windowHeight);

            float[] matrix = CreateOrthoMatrix(windowWidth, windowHeight);
            float[] cursorPosition = [(float)cursorX, (float)cursorY];

            float[] pushConstantData = new float[18];

            Array.Copy(matrix, pushConstantData, 16);
            Array.Copy(cursorPosition, 0, pushConstantData, 16, 2);

            VKK.SetPushConstantData(pushConstantData);

            VKK.Draw(pipeline, vertexBuffer, 3, indexBuffer, 3);
            VKK.Draw(solidPipeline, solidVertexBuffer, 3, indexBuffer, 3);

            VKK.PollEvents();
            VKK.Present(Color.CornflowerBlue);
        }

        VKK.DestroyBuffer(vertexBuffer);
        VKK.DestroyBuffer(solidVertexBuffer);
        VKK.DestroyBuffer(indexBuffer);

        VKK.DestroyUniform(timeUniform);

        VKK.DestroyPipeline(pipeline);
        VKK.DestroyPipeline(solidPipeline);

        VKK.End();
        VKK.TerminateWindowing();
    }

    private static float[] CreateOrthoMatrix(float width, float height) 
    {
        float[] matrix = new float[16];

        for (int i = 0; i < 16; i++)   
            matrix[i] = 0.0f;
    
        matrix[0] = 2.0f / width;
        matrix[5] = 2.0f / height;
        matrix[10] = 1.0f;
        matrix[12] = -1.0f;
        matrix[13] = -1.0f;
        matrix[15] = 1.0f;

        return matrix;
    }
}