namespace NesEmulator.CPU.AddressingModes;

public class ABS : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        throw new NotImplementedException();
    }
}