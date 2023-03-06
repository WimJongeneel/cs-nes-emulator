namespace NesEmulator.CPU.OPCodes;

public class JMP : IOPCode
{
    public string Name => nameof(JMP);

    public bool Execute(CPU6502 cpu)
    {
        cpu.ProgramCounter = cpu.AbsoluteAddress;
        return false;
    }
}