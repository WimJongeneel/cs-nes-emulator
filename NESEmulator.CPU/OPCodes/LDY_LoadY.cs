namespace NESEmulator.CPU.OPCodes;

public class LDY_LoadY : IOPCode
{
    public string Name => nameof(LDX_LoadX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Y = cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.Z, cpu.Y == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.Y & 0x80) > 0);

        return true;
    }
}