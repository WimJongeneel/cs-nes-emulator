using NESEmulator.Bus;

namespace NESEmulator.Memory;

public class RAM : IBusDevice
{
    byte[] Data = new byte[64 * 1024];

    public bool IsInAddressRange(short address)
    {
        return address >= 0x0000 && address <= 0x1FFF;
    }

    public byte read(short address)
    {
        return Data[address];
    }

    public void write(short address, byte data)
    {
        Data[address] = data;
    }
}