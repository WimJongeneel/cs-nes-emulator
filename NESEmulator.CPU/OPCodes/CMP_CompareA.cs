namespace NESEmulator.CPU.OPCodes;

public class CMP_CompareA : IOPCode
{
    public string Name => nameof(CMP_CompareA);

    public bool Execute(CPU6502 cpu)
    {
        var result = (ushort)cpu.A - (ushort)cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.C, cpu.A >= cpu.FetchCache);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x80) > 0);

        return false;
    }
}