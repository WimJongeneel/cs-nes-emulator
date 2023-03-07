namespace NESEmulator.CPU.OPCodes;

public class CLD : IOPCode
{
    public string Name => nameof(CLD);

    public bool Execute(CPU6502 cpu)
    {
        // We dont support the D flag in the NES
        return false;
    }
}