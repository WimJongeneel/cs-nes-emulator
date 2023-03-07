namespace NesEmulator.CPU.OPCodes;

public class SEI : IOPCode
{
    public string Name => nameof(SEI);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.I, true);
        return false;
    }
}