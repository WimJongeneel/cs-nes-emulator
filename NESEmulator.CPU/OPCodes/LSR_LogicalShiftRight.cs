namespace NESEmulator.CPU.OPCodes;

public class LSR_LogicalShiftRight : IOPCode
{
    public string Name => nameof(LSR_LogicalShiftRight);

    public bool Execute(CPU6502 cpu)
    {
        var result = (short)((short)cpu.FetchMemory() >> 1);

        cpu.SetStatusFlag(CPUFlag.C, (cpu.FetchCache & 0x0001) > 0);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x80) > 0);

        if(cpu.AddressingMode.SkipFetch) cpu.A = (byte)result;
        else cpu.Bus.Write(cpu.AbsoluteAddress, (byte)result);

        return false;
    }
}