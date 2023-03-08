namespace NESEmulator.CPU.OPCodes;

public class PHP_PushStatus : IOPCode
{
    public string Name => nameof(PHP_PushStatus);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.Write((byte)(0x0100 + cpu.StackPointer),  (byte)(cpu.Status | (byte)CPUFlag.B | (byte)CPUFlag.U));

        cpu.SetStatusFlag(CPUFlag.B, false);
        cpu.SetStatusFlag(CPUFlag.U, false);

        cpu.StackPointer--;

        return false;
    }
}