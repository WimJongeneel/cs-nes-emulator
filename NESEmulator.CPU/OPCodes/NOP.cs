namespace NESEmulator.CPU.OPCodes;

public class NOP : IOPCode
{
    public string Name => nameof(NOP);

    public bool Execute(CPU6502 cpu)
    {
        return false;
    }
}