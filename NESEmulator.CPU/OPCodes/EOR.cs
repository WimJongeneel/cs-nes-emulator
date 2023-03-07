namespace NESEmulator.CPU.OPCodes;

public class EOR : IOPCode
{
    public string Name => nameof(EOR);

    public bool Execute(CPU6502 cpu)
    {
        cpu.A ^= cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.Z, cpu.A == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.A & 0x80) > 0);

        return true;
    }
}