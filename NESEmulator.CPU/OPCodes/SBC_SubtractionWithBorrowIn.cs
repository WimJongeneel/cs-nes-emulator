namespace NESEmulator.CPU.OPCodes;

public class SBC_SubtractionWithBorrowIn : IOPCode
{
    public string Name => nameof(SBC_SubtractionWithBorrowIn);

    public bool Execute(CPU6502 cpu)
    {
        cpu.FetchMemory();

        ushort tmp = (ushort)((ushort)cpu.FetchCache ^ 0x00FF);
        ushort result = (ushort)((ushort)cpu.A + tmp + (ushort)(cpu.GetStatusFlag(CPUFlag.C) ? 1 : 0));

        cpu.SetStatusFlag(CPUFlag.C, (result & 0xFF00) > 0);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0);
        cpu.SetStatusFlag(CPUFlag.V, ( (result ^ (ushort)cpu.A) & (result ^ tmp) & 0x0080) > 0);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x0080) > 0);

        cpu.A = (byte)result;

        return true;
    }
}