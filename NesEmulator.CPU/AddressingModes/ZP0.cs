namespace NesEmulator.CPU.AddressingModes;

public class ZP0 : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.AbsoluteAddress = (short)(cpu.Bus.Read(cpu.ProgramCounter) & 0x00FF);
        cpu.ProgramCounter++;
        return false;
    }
}