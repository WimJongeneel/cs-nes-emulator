namespace NESEmulator.CPU.OPCodes;

public class TAY : IOPCode
{
    public string Name => nameof(TAY);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Y = cpu.A;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.Y == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.Y & 0x80) > 0);

        return false;
    }
}