using NESEmulator.Bus;
using NESEmulator.Cartridge;
using NESEmulator.Controller;

namespace NESEmulator;

public class Program
{
    public static void Main(string[] args)
    {
        var nes = new CPUBus();
        // nes.InsertCartridge(CartridgeReader.Read("./nestest.nes"));

        var controller = new NESKeyboardController();

        while(true)
        {
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(Convert.ToString(controller.Read(0), 2).PadLeft(8, '0'));
        }
    }
}