using NesEmulator.CPU.AddressingModes;

namespace NesEmulator.CPU.OPCodes;

public class NOP : IOPCode
{
    public string Name => nameof(NOP);

    public bool Execute(CPU6502 cpu)
    {
        return false;
    }
}