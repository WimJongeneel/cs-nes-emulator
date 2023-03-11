namespace NESEmulator.CPU.OPCodes;

public class RTS_ReturnFromSubroutine : IOPCode
{
    public string Name => nameof(RTS_ReturnFromSubroutine);

    public bool Execute(CPU6502 cpu)
    {
        cpu.ProgramCounter = (ushort)((ushort)cpu.Bus.Read((ushort)(0x0100 + ++cpu.StackPointer)) | (ushort)(cpu.Bus.Read((ushort)(0x0100 + ++cpu.StackPointer)) << 8));
        cpu.ProgramCounter++;

        return false;
    }
}