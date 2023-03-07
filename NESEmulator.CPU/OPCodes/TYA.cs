namespace NESEmulator.CPU.OPCodes;

public class TYA : IOPCode
{
    public string Name => nameof(TYA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.A = cpu.Y;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.A == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.A & 0x80) > 0);

        return false;
    }
}