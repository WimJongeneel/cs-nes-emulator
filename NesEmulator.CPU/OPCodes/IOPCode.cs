using NesEmulator.CPU.AddressingModes;

namespace NesEmulator.CPU.OPCodes;

public interface IOPCode
{
    bool Execute(CPU6502 cpu);
    string Name { get; }
}