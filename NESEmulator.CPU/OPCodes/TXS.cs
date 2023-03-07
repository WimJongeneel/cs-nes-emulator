namespace NESEmulator.CPU.OPCodes;

public class TXS : IOPCode
{
    public string Name => nameof(TXS);

    public bool Execute(CPU6502 cpu)
    {
        cpu.StackPointer = cpu.X;
        return false;
    }
}