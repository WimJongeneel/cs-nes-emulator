using NESEmulator.Bus;

namespace NESEmulator.Cartridge;

public class CartridgeReader
{
    public static CartridgeReader LoadFromFilePath(string path)
    {
        return null;
    }

    public IBusDevice GetPPUAdapter()
    {
        return null;
    }

    public IBusDevice GetCPUAdapter()
    {
        return null;
    }
}