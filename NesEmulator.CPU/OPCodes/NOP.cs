using NesEmulator.CPU.AddressingModes;

namespace NesEmulator.CPU.OPCodes;

public class NOP : IOPCode
{
    public IAddressingMode AddressingMode => new IMP();

    public string Name => nameof(NOP);

    public bool Execute(CPU6502 cpu)
    {
        return false;
    }
}