using NESEmulator.Bus;
using NESEmulator.Cartridge;

namespace NESEmulator;

public class Program
{
    public static void Main(string[] args)
    {
        var nes = new CPUBus();
        nes.InsertCartridge(CartridgeReader.Read("./nestest.nes"));
    }
}