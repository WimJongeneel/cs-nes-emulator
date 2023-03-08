namespace NESEmulator.CPU.OPCodes;

public class ROR_RotateRight : IOPCode
{
    public string Name => nameof(ROR_RotateRight);

    public bool Execute(CPU6502 cpu)
    {
        var result = (short)(((cpu.GetStatusFlag(CPUFlag.C) ? 1 : 0) << 7) | ((short)cpu.FetchMemory() >> 1));

        cpu.SetStatusFlag(CPUFlag.C, (cpu.FetchCache & 0x01) > 0);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0xFF00) == 0);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x0080) > 0);

        if(cpu.AddressingMode.SkipFetch) cpu.A = (byte)result;
        else cpu.Bus.Write(cpu.AbsoluteAddress, (byte)result);

        return false;
    }
}