namespace NESEmulator.Bus;

public interface IBusDevice
{
    bool IsInAddressRange(ushort address);
    void write(ushort address, byte data);
    byte read(ushort address);
}