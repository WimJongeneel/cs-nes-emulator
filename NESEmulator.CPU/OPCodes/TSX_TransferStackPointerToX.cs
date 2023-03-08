namespace NESEmulator.CPU.OPCodes;

public class TSX_TransferStackPointerToX : IOPCode
{
    public string Name => nameof(TSX_TransferStackPointerToX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.X = cpu.StackPointer;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.X == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.X & 0x80) > 0);

        return false;
    }
}