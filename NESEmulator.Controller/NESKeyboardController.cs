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

    public byte Read(ushort address)
    {
        var result = 0;

        result |= (GetKeyState(88) & 0x8000) > 0 ? 0x80 : 0x00; // X => A
        result |= (GetKeyState(90) & 0x8000) > 0 ? 0x40 : 0x00; // Z => B
        result |= (GetKeyState(65) & 0x8000) > 0 ? 0x20 : 0x00; // A => Select
        result |= (GetKeyState(83) & 0x8000) > 0 ? 0x10 : 0x00; // S => Start
        result |= (GetKeyState(38) & 0x8000) > 0 ? 0x08 : 0x00; // UP => UP
        result |= (GetKeyState(40) & 0x8000) > 0 ? 0x04 : 0x00; // DOWN => DOWN
        result |= (GetKeyState(37) & 0x8000) > 0 ? 0x02 : 0x00; // LEFT => LEFT
        result |= (GetKeyState(39) & 0x8000) > 0 ? 0x01 : 0x00; // RIGHT => RIGHT

        return (byte)result;
    }

    public void Write(ushort address, byte data)
    {
        // you can't write to the controller
    }
}