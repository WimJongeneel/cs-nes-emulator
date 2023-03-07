namespace NESEmulator.CPU.OPCodes;

public class DEY : IOPCode
{
    public string Name => nameof(DEY);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Y--;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.Y == 0x00);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.Y & 0x80) > 0);

        return false;
    }
}