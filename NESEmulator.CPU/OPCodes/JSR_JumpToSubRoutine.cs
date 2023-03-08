namespace NESEmulator.CPU.OPCodes;

public class JSR_JumpToSubRoutine : IOPCode
{
    public string Name => nameof(JSR_JumpToSubRoutine);

    public bool Execute(CPU6502 cpu)
    {
        cpu.ProgramCounter--;

        cpu.Bus.Write((short)(0x0100 + cpu.StackPointer), (byte)((cpu.ProgramCounter >> 8) & 0x00FF));
        cpu.StackPointer--;
        cpu.Bus.Write((short)(0x0100 + cpu.StackPointer), (byte)((cpu.ProgramCounter & 0x00FF)));
        cpu.StackPointer--;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}