namespace NesEmulator.CPU.AddressingModes;

public class ZPX : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.AbsoluteAddress = (short)(cpu.Bus.Read((short)(cpu.ProgramCounter + cpu.X)) & 0x00FF);
        cpu.ProgramCounter++;
        return false;
    }
}