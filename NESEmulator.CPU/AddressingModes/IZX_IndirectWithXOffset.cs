namespace NESEmulator.CPU.AddressingModes;

public class IZX_IndirectWithXOffset : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        ushort pointerPointer = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        byte low = cpu.Bus.Read((ushort)((pointerPointer + cpu.X) & 0x00FF));
        ushort high = cpu.Bus.Read((ushort)((pointerPointer + cpu.X + 1) & 0x00FF));

        cpu.AbsoluteAddress = (ushort)((high << 8) | low);

        return false;
    }
}