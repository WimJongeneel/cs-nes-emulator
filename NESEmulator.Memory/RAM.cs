using NESEmulator.Bus;

namespace NESEmulator.Memory;

public class RAM : IBusDevice
{
    byte[] Data = new byte[2048];

    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x0000 && address <= 0x1FFF;
    }

    public byte read(ushort address)
    {
        return Data[address % 2048];
    }

    public void write(ushort address, byte data)
    {
        Data[address % 2048] = data;
    }
}