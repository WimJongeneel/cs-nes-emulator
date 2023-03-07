namespace NesEmulator.CPU.OPCodes;

public class SED : IOPCode
{
    public string Name => nameof(SED);

    public bool Execute(CPU6502 cpu)
    {
        // We dont support the D flag in the NES
        return false;
    }
}