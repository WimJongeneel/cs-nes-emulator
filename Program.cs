using NESEmulator.Bus;

namespace NESEmulator;

public class Program
{
    public static void Main(string[] args)
    {
        var nes = new CpuBus();

        var p = new byte[] {
            0xA5, 0x00, 0x0A, 0x85, 0x64, 0x0A, 0x0A, 0x18, 0x65, 0x64, 0x60
        };

        for(short i = 0; i < p.Length; i++)
            nes.Write(i, p[i]);

        for(short i = 0; i < 7; i++)
            nes.ClockFullInstruction();


        Console.WriteLine("A: " + nes.CPU.A);
        Console.WriteLine("X: " + nes.CPU.X);
        Console.WriteLine("Y: " + nes.CPU.Y);
    }
}