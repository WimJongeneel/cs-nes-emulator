namespace NesEmulator.Bus;

public interface IBus
{
    void write(short address, byte data);
    byte Read(short address, bool _readonly = false);
}