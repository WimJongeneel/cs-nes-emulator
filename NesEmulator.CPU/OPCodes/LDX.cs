namespace NesEmulator.CPU.OPCodes;

public class LDX : IOPCode
{
    public string Name => nameof(LDX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.X = cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.Z, cpu.X == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.X & 0x80) > 0);

        return true;
    }
}