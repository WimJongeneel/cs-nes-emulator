using NESEmulator.CPU.AddressingModes;

namespace NESEmulator.CPU.OPCodes;

public record Instruction(IOPCode OPCode, IAddressingMode AddressingMode, int Cycles)
{
    public static implicit operator Instruction((IOPCode, IAddressingMode, int) value)
    {
        return new Instruction(value.Item1, value.Item2, value.Item3);
    }
}