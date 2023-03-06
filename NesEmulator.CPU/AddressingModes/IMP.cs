namespace NesEmulator.CPU.AddressingModes;

public class IMP : IAddressingMode
{
    public bool Execute(CPU6502 cpu)
    {
        cpu.FetchCache = cpu.A;
        return false;
    }
}