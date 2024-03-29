namespace NESEmulator.CPU.OPCodes;

public class DEX_DecrementX : IOPCode
{
    public string Name => nameof(DEX_DecrementX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.X--;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.X == 0x00);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.X & 0x80) > 0);

        return false;
    }
}