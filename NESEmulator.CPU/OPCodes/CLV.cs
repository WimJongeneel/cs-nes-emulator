namespace NESEmulator.CPU.OPCodes;

public class CLV : IOPCode
{
    public string Name => nameof(CLV);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.V, false);
        return false;
    }
}