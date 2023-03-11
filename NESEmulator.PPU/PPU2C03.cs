using NESEmulator.Bus;

namespace NESEmulator.PPU;

public class PPU2C02 : IBusDevice
{
    IBus Bus { get; init; }
    byte[] Data { get; } = new byte[8];

    public PPU2C02(IBus bus)
    {
        Bus = bus ?? throw new ArgumentNullException();
    }

    public void ClockSingleTick()
    {

    }

    public bool IsInAddressRange(short address)
    {
        return address >= 0x2000 && address <= 0x3FFF;
    }

    public void write(short address, byte data)
    {
        Data[address & 0x0007] = data;
    }

    public byte read(short address)
    {
        return Data[address & 0x0007];
    }
}