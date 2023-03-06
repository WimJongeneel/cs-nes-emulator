using NesEmulator.CPU.AddressingModes;

namespace NesEmulator.CPU.OPCodes;

public interface OPCode
{
    bool Execute(CPU6502 cpu);
    IAddressingMode AddressingMode { get; }
    string Name { get; }
    int Cycles { get; }
}