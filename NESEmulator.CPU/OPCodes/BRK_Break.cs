namespace NESEmulator.CPU.OPCodes;

public class BRK_Break : IOPCode
{
    public string Name => nameof(BRK_Break);

    public bool Execute(CPU6502 cpu)
    {
        cpu.SetStatusFlag(CPUFlag.I, true);
        cpu.Bus.Write((ushort)(0x0100 + cpu.StackPointer--), (byte)((++cpu.ProgramCounter >> 8) & 0x00FF));
        cpu.Bus.Write((ushort)(0x0100 + cpu.StackPointer--), (byte)(cpu.ProgramCounter & 0x00FF));

        cpu.SetStatusFlag(CPUFlag.B, true);
        cpu.Bus.Write((ushort)(0x0100 + cpu.StackPointer--), cpu.Status);
        cpu.SetStatusFlag(CPUFlag.B, false);

        cpu.ProgramCounter = (ushort)((ushort)cpu.Bus.Read(0xFFFE) | ((ushort)cpu.Bus.Read(0xFFFF) << 8));

        return false;
    }
}