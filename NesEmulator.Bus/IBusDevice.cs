namespace NesEmulator.Bus;

public interface IBusDevice
{
    bool IsInAddressRange(short address);
    void write(short address, byte data);
    byte read(short address);
}