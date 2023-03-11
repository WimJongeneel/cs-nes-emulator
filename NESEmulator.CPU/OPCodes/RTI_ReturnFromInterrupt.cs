namespace NESEmulator.CPU.OPCodes;

public class RTI_ReturnFromInterrupt : IOPCode
{
    public string Name => nameof(RTI_ReturnFromInterrupt);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Status = cpu.Bus.Read((ushort)(0x0100 + ++cpu.StackPointer));
        cpu.Status &= (byte)~CPUFlag.B;
        cpu.Status &= (byte)~CPUFlag.U;

        cpu.ProgramCounter = (ushort)((ushort)cpu.Bus.Read((ushort)(0x0100 + ++cpu.StackPointer)) | (ushort)(cpu.Bus.Read((ushort)(0x0100 + ++cpu.StackPointer)) << 8));

        return false;
    }
}