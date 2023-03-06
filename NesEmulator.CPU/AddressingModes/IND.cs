namespace NesEmulator.CPU.AddressingModes;

public class IND : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        byte low = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;
        short high = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        short pointer = (short)(((high << 8) | low) + cpu.Y);

        // This if-statement emulates a NES hardware bug with moving past the zero page
        if (low == 0x00FF) 
            cpu.AbsoluteAddress = (short)((cpu.Bus.Read((short)(pointer & 0xFF00)) << 8) | cpu.Bus.Read(pointer));
        else 
            cpu.AbsoluteAddress = (short)((cpu.Bus.Read((short)(pointer + 1)) << 8) | cpu.Bus.Read(pointer));

        return false;
    }
}