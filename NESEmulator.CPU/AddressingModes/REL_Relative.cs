namespace NESEmulator.CPU.AddressingModes;

public class REL_Relative : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.RelativeAddressOffset = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        // TODO: find dotnet way of wrapp around
        // if ((cpu.RelativeAddressOffset & 0x80) > 1)
        //     cpu.RelativeAddressOffset |= 0xFF00;
        
        return false;
    }
}