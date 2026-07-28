using System.Runtime.InteropServices;
using VkKatzi;

internal static class Program
{
    private static void Main(string[] args)
    {
        nint window = VKK.CreateWindow(800, 600, "Katzi lel");

        VkKatziConfig config = new()
        {
            PresentMode = PresentMode.Mailbox,
            ImageBufferSize = 3,
            EnableValidationLayers = false,
            VerboseLogging = true
        };

        PhysicalDeviceInfo deviceInfo = VKK.InitDevice(window, config);

        if (!deviceInfo.Success)
            throw new Exception("Failed to initialize Device");

        Console.WriteLine($"[GPU]: Name: {deviceInfo.Name}, Type: {Enum.GetName(deviceInfo.DeviceType)}");

        Uniform timeUniform = VKK.CreateUniform(0, sizeof(float), ShaderStage.Vertex);

        PushConstantRange pushConstantRange = new()
        {
            ShaderStage = ShaderStage.All,
            Offset = 0,
            Size = sizeof(float) * 18
        };

        if (!VKK.InitPipeline(pushConstantRange))
            throw new Exception("Failed to initialize Pipeline");
        
        Vertex[] vertices = {
            new() { X = 0, Y = -1, R = 1, A = 1 },
            new() { X = 1, Y = 1, G = 1, A = 1 },
            new() { X = -1, Y = 1, B = 1, A = 1 },
        };

        ushort[] indices =
        {
            0, 1, 2
        };

        Buffer vertexBuffer = VKK.CreateBuffer((nuint)Marshal.SizeOf<Vertex>() * 3, BufferUsage.Vertex);
        VKK.WriteBuffer(vertexBuffer, vertices);

        Buffer indexBuffer = VKK.CreateBuffer((nuint)Marshal.SizeOf<ushort>() * 3, BufferUsage.Index);
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

            VKK.Draw(vertexBuffer, 3, indexBuffer, 3);

            VKK.PollEvents();
            VKK.Present();
        }

        VKK.DestroyBuffer(vertexBuffer);
        VKK.DestroyBuffer(indexBuffer);

        VKK.DestroyUniform(timeUniform);

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