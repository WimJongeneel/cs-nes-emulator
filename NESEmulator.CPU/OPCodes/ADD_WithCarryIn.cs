namespace NESEmulator.CPU.OPCodes;

public class ADD_WithCarryIn : IOPCode
{
    public string Name => nameof(ADD_WithCarryIn);

    public bool Execute(CPU6502 cpu)
    {
        cpu.FetchMemory();

        ushort result = (ushort)((ushort)cpu.A + (ushort)cpu.FetchCache + (ushort)(cpu.GetStatusFlag(CPUFlag.C) ? 1 : 0));

        cpu.SetStatusFlag(CPUFlag.C, result > 255);
        cpu.SetStatusFlag(CPUFlag.Z, (byte)result == 0);
        cpu.SetStatusFlag(CPUFlag.V, ~(((ushort)cpu.A ^ (ushort)cpu.FetchCache & ((ushort)cpu.A ^ result)) & 0x0080) > 0);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x80) > 0);

        cpu.A = (byte)result;

        return true;
    }
}