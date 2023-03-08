namespace NESEmulator.CPU.OPCodes;

public class SED_SetDecimalFlag : IOPCode
{
    public string Name => nameof(SED_SetDecimalFlag);

    public bool Execute(CPU6502 cpu)
    {
        // We dont support the D flag in the NES
        return false;
    }
}