namespace NESEmulator.CPU.OPCodes;

public class SEI_SetInterruptFlag : IOPCode
{
    public string Name => nameof(SEI_SetInterruptFlag);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.I, true);
        return false;
    }
}