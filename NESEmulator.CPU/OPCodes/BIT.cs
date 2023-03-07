namespace NESEmulator.CPU.OPCodes;

public class BIT : IOPCode
{
    public string Name => nameof(BIT);

    public bool Execute(CPU6502 cpu)
    {
        var result = (short)(cpu.A & cpu.FetchMemory());

        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0x00);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.FetchCache & (1 << 7)) > 0);
        cpu.SetStatusFlag(CPUFlag.V, (cpu.FetchCache & (1 << 6)) > 0);

        return false;
    }
}