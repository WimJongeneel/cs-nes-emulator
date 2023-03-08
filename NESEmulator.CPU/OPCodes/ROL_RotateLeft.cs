namespace NESEmulator.CPU.OPCodes;

public class ROL_RotateLeft : IOPCode
{
    public string Name => nameof(ROL_RotateLeft);

    public bool Execute(CPU6502 cpu)
    {
        var result = (short)(((short)cpu.FetchMemory() << 1) | (cpu.GetStatusFlag(CPUFlag.C) ? 1 : 0));

        cpu.SetStatusFlag(CPUFlag.C, (result & 0xFF00) > 0);
        cpu.SetStatusFlag(CPUFlag.Z, (result & 0xFF00) == 0);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x80) > 0);

        if(cpu.AddressingMode.SkipFetch) cpu.A = (byte)result;
        else cpu.Bus.Write(cpu.AbsoluteAddress, (byte)result);

        return false;
    }
}