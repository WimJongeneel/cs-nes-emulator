namespace NESEmulator.CPU.AddressingModes;

public class ZPY : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.AbsoluteAddress = (short)(cpu.Bus.Read((short)(cpu.ProgramCounter + cpu.Y)) & 0x00FF);
        cpu.ProgramCounter++;
        return false;
    }
}