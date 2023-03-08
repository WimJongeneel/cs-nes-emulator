namespace NESEmulator.CPU.OPCodes;

public class TXS_TransferXToStackPointer : IOPCode
{
    public string Name => nameof(TXS_TransferXToStackPointer);

    public bool Execute(CPU6502 cpu)
    {
        cpu.StackPointer = cpu.X;
        return false;
    }
}