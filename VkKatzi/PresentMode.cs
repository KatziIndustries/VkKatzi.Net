namespace VkKatzi;

public enum PresentMode
{
    Immediate = 0,
    Mailbox = 1,
    FIFO = 2,
    FIFO_Relaxed = 3,
    SharedDemandRefresh = 1000111000,
    SharedContinousRefresh = 1000111001,
    FIFOLatestReady = 1000361000
}