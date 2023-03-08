namespace NESEmulator.CPU.OPCodes;

public class CLD_ClearDecimalFlag : IOPCode
{
    public string Name => nameof(CLD_ClearDecimalFlag);

    public bool Execute(CPU6502 cpu)
    {
        // We dont support the D flag in the NES
        return false;
    }
}