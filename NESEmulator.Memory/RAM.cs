using NESEmulator.Bus;

namespace NESEmulator.Memory;

public class RAM : IBusDevice
{
    byte[] Data = new byte[2048];

    public bool IsInAddressRange(short address)
    {
        return address >= 0x0000 && address <= 0x1FFF;
    }

    public byte read(short address)
    {
        return Data[address % 2048];
    }

    public void write(short address, byte data)
    {
        Data[address % 2048] = data;
    }
}