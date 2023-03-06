namespace NesEmulator.CPU.AddressingModes;

public class IZX : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        short pointerPointer = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        byte low = cpu.Bus.Read((short)((pointerPointer + cpu.X) & 0x00FF));
        short high = cpu.Bus.Read((short)((pointerPointer + cpu.X + 1) & 0x00FF));

        cpu.AbsoluteAddress = (short)((high << 8) | low);

        return false;
    }
}