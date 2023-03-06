namespace NesEmulator.CPU.AddressingModes;

public class IMM : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.AbsoluteAddress = cpu.ProgramCounter;
        cpu.ProgramCounter++;
        return false;
    }
}