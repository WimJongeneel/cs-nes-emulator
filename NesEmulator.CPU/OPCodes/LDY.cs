namespace NesEmulator.CPU.OPCodes;

public class LDY : IOPCode
{
    public string Name => nameof(LDX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Y = cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.Z, cpu.Y == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.Y & 0x80) > 0);

        return true;
    }
}