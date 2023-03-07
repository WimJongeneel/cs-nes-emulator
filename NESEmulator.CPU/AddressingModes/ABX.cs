namespace NESEmulator.CPU.AddressingModes;

public class ABX : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        byte low = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;
        short high = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        cpu.AbsoluteAddress = (short)(((high << 8) | low) + cpu.X);

        return ((cpu.AbsoluteAddress & 0xFF00) != (high << 8));
    }
}