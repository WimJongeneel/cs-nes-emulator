namespace NESEmulator.CPU.OPCodes;

public class SEV_SetOverflowFlag : IOPCode
{
    public string Name => nameof(SEV_SetOverflowFlag);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.V, true);
        return false;
    }
}