using NESEmulator.Bus;

namespace NESEmulator.Memory;

public class PaletTable : IBusDevice
{
    byte[] Data = new byte[32];

    // TODO: correct addressing ranges and address mapping / mirroring
    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x0000 && address <= 0x1FFF;
    }

    public byte read(ushort address)
    {
        return Data[address % 32];
    }

    public void write(ushort address, byte data)
    {
        Data[address % 32] = data;
    }
}