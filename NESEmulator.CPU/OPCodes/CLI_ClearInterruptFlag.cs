namespace NESEmulator.CPU.OPCodes;

public class CLI_ClearInterruptFlag : IOPCode
{
    public string Name => nameof(CLI_ClearInterruptFlag);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.I, false);
        return false;
    }
}