namespace NESEmulator.CPU.OPCodes;

public class CPY_CompareY : IOPCode
{
    public string Name => nameof(CPY_CompareY);

    public bool Execute(CPU6502 cpu)
    {
        var result = (ushort)cpu.Y - (ushort)cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.C, cpu.Y >= cpu.FetchCache);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x80) > 0);

        return false;
    }
}