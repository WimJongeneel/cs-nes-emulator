namespace NesEmulator.CPU.AddressingModes;

public class IND : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        throw new NotImplementedException();
    }
}