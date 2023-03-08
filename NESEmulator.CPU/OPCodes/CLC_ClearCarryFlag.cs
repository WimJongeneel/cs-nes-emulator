namespace NESEmulator.CPU.OPCodes;

public class CLC_ClearCarryFlag : IOPCode
{
    public string Name => nameof(CLC_ClearCarryFlag);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.C, false);
        return false;
    }
}