namespace NESEmulator.Bus;

public interface IBusDevice
{
    bool IsInAddressRange(ushort address);
    void Write(ushort address, byte data);
    byte Read(ushort address);
}