namespace NESEmulator.CPU.OPCodes;

public class DEC_DecrementAtMemoryAddress : IOPCode
{
    public string Name => nameof(DEC_DecrementAtMemoryAddress);

    public bool Execute(CPU6502 cpu)
    {
        ushort result = (ushort)(cpu.FetchMemory() - 1);
        cpu.Bus.Write(cpu.AbsoluteAddress, (byte)(result & 0x00FF));

        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x0080) > 0);

        return false;
    }
}