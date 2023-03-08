namespace NESEmulator.CPU.AddressingModes;

public class IMM_Immediate : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.AbsoluteAddress = cpu.ProgramCounter;
        cpu.ProgramCounter++;
        return false;
    }
}