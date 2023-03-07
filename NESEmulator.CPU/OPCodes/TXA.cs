namespace NESEmulator.CPU.OPCodes;

public class TXA : IOPCode
{
    public string Name => nameof(TXA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.A = cpu.X;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.A == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.A & 0x80) > 0);

        return false;
    }
}