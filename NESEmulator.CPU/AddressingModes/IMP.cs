namespace NESEmulator.CPU.AddressingModes;

public class IMP : IAddressingMode
{
    public bool SkipFetch => true;

    public bool Execute(CPU6502 cpu)
    {
        cpu.FetchCache = cpu.A;
        return false;
    }
}