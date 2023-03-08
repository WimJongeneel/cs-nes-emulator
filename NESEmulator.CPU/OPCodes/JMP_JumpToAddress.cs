namespace NESEmulator.CPU.OPCodes;

public class JMP_JumpToAddress : IOPCode
{
    public string Name => nameof(JMP_JumpToAddress);

    public bool Execute(CPU6502 cpu)
    {
        cpu.ProgramCounter = cpu.AbsoluteAddress;
        return false;
    }
}