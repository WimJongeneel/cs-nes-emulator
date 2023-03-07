namespace NESEmulator.CPU.OPCodes;

public class JSR : IOPCode
{
    public string Name => nameof(JSR);

    public bool Execute(CPU6502 cpu)
    {
        cpu.ProgramCounter--;

        cpu.Bus.write((short)(0x0100 + cpu.StackPointer), (byte)((cpu.ProgramCounter >> 8) & 0x00FF));
        cpu.StackPointer--;
        cpu.Bus.write((short)(0x0100 + cpu.StackPointer), (byte)((cpu.ProgramCounter & 0x00FF)));
        cpu.StackPointer--;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}