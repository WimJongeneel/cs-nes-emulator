namespace NESEmulator.Bus;

public interface IBus
{
    void Write(short address, byte data);
    byte Read(short address, bool _readonly = false);
}