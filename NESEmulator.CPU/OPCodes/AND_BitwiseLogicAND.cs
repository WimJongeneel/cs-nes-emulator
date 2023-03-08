namespace NESEmulator.CPU.OPCodes;

public class AND_BitwiseLogicAND : IOPCode
{
    public string Name => nameof(AND_BitwiseLogicAND);

    public bool Execute(CPU6502 cpu)
    {
        cpu.FetchMemory();
        cpu.A &= cpu.FetchCache;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.A == 0x00);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.A & 0x80) > 0);

        return true;
    }
}