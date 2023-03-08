namespace NESEmulator.CPU.OPCodes;

public class PHA_PushA : IOPCode
{
    public string Name => nameof(PHA_PushA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.Write((byte)(0x0100 + cpu.StackPointer),  cpu.A);
        cpu.StackPointer--;
        return false;
    }
}