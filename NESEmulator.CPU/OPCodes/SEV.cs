namespace NESEmulator.CPU.OPCodes;

public class SEV : IOPCode
{
    public string Name => nameof(SEV);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.V, true);
        return false;
    }
}