namespace NESEmulator.CPU.AddressingModes;

public class ZPX_ZeroPageWithXOffset : IAddressingMode
{
    public bool SkipFetch => false;

    public bool Execute(CPU6502 cpu)
    {
        cpu.AbsoluteAddress = (ushort)(cpu.Bus.Read((ushort)(cpu.ProgramCounter + cpu.X)) & 0x00FF);
        cpu.ProgramCounter++;
        return false;
    }
}