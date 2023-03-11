namespace NESEmulator.CPU.AddressingModes;

public class ABS_Absolute : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        byte low = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;
        ushort high = cpu.Bus.Read(cpu.ProgramCounter);
        cpu.ProgramCounter++;

        cpu.AbsoluteAddress = (ushort)((high << 8) | low);

        return false;
    }
}