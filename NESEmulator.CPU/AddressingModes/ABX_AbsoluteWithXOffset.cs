namespace NESEmulator.CPU.AddressingModes;

public class ABX_AbsoluteWithXOffset : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        byte low = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;
        ushort high = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        cpu.AbsoluteAddress = (ushort)(((high << 8) | low) + cpu.X);

        return ((cpu.AbsoluteAddress & 0xFF00) != (high << 8));
    }
}