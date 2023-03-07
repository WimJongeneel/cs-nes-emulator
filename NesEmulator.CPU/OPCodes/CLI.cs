namespace NesEmulator.CPU.OPCodes;

public class CLI : IOPCode
{
    public string Name => nameof(CLI);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.I, false);
        return false;
    }
}