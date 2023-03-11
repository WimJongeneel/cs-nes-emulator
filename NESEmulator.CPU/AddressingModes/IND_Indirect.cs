namespace NESEmulator.CPU.AddressingModes;

public class IND_Indirect : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        byte low = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;
        ushort high = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        ushort pointer = (ushort)(((high << 8) | low) + cpu.Y);

        // This if-statement emulates a NES hardware bug with moving past the zero page
        if (low == 0x00FF) 
            cpu.AbsoluteAddress = (ushort)((cpu.Bus.Read((ushort)(pointer & 0xFF00)) << 8) | cpu.Bus.Read(pointer));
        else 
            cpu.AbsoluteAddress = (ushort)((cpu.Bus.Read((ushort)(pointer + 1)) << 8) | cpu.Bus.Read(pointer));

        return false;
    }
}