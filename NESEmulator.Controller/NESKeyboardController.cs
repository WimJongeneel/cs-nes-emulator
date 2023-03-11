using System.Runtime.InteropServices;
using NESEmulator.Bus;

namespace NESEmulator.Controller;

public class NESKeyboardController : IBusDevice
{
    [DllImport("user32.dll")]
    static extern int GetKeyState(int key);

    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x4016 && address <= 0x4017;
    }

    public byte read(ushort address)
    {
        // var left = (GetKeyState(37) & 0x8000) > 0;
        return 0;
    }

    public void write(ushort address, byte data)
    {
        // you can't write to the controller
    }
}