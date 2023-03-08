namespace NESEmulator.CPU.OPCodes;

public class CLV_ClearOverflowFlag : IOPCode
{
    public string Name => nameof(CLV_ClearOverflowFlag);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.V, false);
        return false;
    }
}