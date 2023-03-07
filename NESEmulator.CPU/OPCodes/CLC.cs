namespace NESEmulator.CPU.OPCodes;

public class CLC : IOPCode
{
    public string Name => nameof(CLC);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.C, false);
        return false;
    }
}