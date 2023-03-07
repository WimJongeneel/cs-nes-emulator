namespace NesEmulator.CPU.OPCodes;

public class SEC : IOPCode
{
    public string Name => nameof(SEC);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.C, true);
        return false;
    }
}