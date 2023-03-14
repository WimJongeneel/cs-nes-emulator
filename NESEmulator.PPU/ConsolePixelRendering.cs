using System.Runtime.InteropServices;
using System.Text;

namespace NESEmulator.PPU;

public class ConsolePixelRendering : IDisposable
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    public ConsolePixelRendering()
    {
        var handle = GetStdHandle(-11);
        GetConsoleMode(handle, out var mode);
        SetConsoleMode(handle, mode | 0x4);
        Console.Clear();
        Console.SetBufferSize(257 * 2, 242);
    }

    public static void RenderPixel(int x, int y, int r, int g, int b)
    {
        if(x is < 0 or > 256) return;
        if(y is < 0 or > 240) return;

        Console.SetCursorPosition(x * 2, y);
        Console.Write("\x1b[38;2;" + r + ";" + g + ";" + b + "m");
        Console.Write("██");
    }

    public void Dispose()
    {
        Console.ResetColor();
    }
}