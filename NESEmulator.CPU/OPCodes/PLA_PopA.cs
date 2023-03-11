namespace NESEmulator.CPU.OPCodes;

public class PLA_PopA : IOPCode
{
    public string Name => nameof(PLA_PopA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.StackPointer++;
        cpu.A = cpu.Bus.Read((ushort)(0x0100 + cpu.StackPointer));

        cpu.SetStatusFlag(CPUFlag.Z, cpu.A == 0x00);
        cpu.SetStatusFlag(CPUFlag.N, (cpu.A & 0x80) > 0);

        return false;
    }
}