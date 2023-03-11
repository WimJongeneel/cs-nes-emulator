namespace NESEmulator.CPU.OPCodes;

public class PLP_PopStatus : IOPCode
{
    public string Name => nameof(PLP_PopStatus);

    public bool Execute(CPU6502 cpu)
    {
        cpu.StackPointer++;
        cpu.Status = cpu.Bus.Read((ushort)(0x0100 + cpu.StackPointer));

        cpu.SetStatusFlag(CPUFlag.U, true);

        return false;
    }
}