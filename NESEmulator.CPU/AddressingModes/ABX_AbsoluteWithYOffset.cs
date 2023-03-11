namespace NESEmulator.CPU.AddressingModes;

public class ABY_AbsoluteWithYOffset : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        byte low = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;
        ushort high = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        cpu.AbsoluteAddress = (ushort)(((high << 8) | low) + cpu.Y);

        return ((cpu.AbsoluteAddress & 0xFF00) != (high << 8));
    }
}