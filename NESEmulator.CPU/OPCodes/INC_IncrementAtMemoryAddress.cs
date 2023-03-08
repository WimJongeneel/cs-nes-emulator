namespace NESEmulator.CPU.OPCodes;

public class INC_IncrementAtMemoryAddress : IOPCode
{
    public string Name => nameof(INC_IncrementAtMemoryAddress);

    public bool Execute(CPU6502 cpu)
    {
        short result = (short)(cpu.FetchMemory() + 1);
        cpu.Bus.write(cpu.AbsoluteAddress, (byte)(result & 0x00FF));

        cpu.SetStatusFlag(CPUFlag.Z, (result & 0x00FF) == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (result & 0x0080) > 0);

        return false;
    }
}