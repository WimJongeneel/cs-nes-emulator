using NESEmulator.CPU.AddressingModes;

namespace NESEmulator.CPU.OPCodes;

public interface IOPCode
{
    bool Execute(CPU6502 cpu);
    string Name { get; }
}