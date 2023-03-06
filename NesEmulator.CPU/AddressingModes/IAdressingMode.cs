namespace NesEmulator.CPU.AddressingModes;

public interface IAddressingMode
{
    bool Execute(CPU6502 cpu);
}