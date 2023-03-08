namespace NESEmulator.CPU.OPCodes;

public class LDA_LoadA : IOPCode
{
    public string Name => nameof(LDA_LoadA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.A = cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.Z, cpu.A == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.A & 0x80) > 0);

        return true;
    }
}