namespace NESEmulator.CPU.OPCodes;

public class TAX_TransferAToX : IOPCode
{
    public string Name => nameof(TAX_TransferAToX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.X = cpu.A;

        cpu.SetStatusFlag(CPUFlag.Z, cpu.X == 0x0000);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.X & 0x80) > 0);

        return false;
    }
}