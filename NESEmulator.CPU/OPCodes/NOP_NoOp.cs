namespace NESEmulator.CPU.OPCodes;

public class NOP_NoOp : IOPCode
{
    public string Name => nameof(NOP_NoOp);

    public bool Execute(CPU6502 cpu)
    {
        return false;
    }
}