namespace NESEmulator.CPU.OPCodes;

public class CPX_CompareX : IOPCode
{
    public string Name => nameof(CPX_CompareX);

    public bool Execute(CPU6502 cpu)
    {
        var result = (ushort)cpu.X - (ushort)cpu.FetchMemory();

        cpu.SetStatusFlag(CPUFlag.C, cpu.X >= cpu.FetchCache);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x80) > 0);

        return false;
    }
}