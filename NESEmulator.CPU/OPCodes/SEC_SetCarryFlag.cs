namespace NESEmulator.CPU.OPCodes;

public class SEC_SetCarryFlag : IOPCode
{
    public string Name => nameof(SEC_SetCarryFlag);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.C, true);
        return false;
    }
}