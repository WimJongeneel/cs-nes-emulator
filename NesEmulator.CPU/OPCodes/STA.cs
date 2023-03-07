namespace NesEmulator.CPU.OPCodes;

public class STA : IOPCode
{
    public string Name => nameof(STA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.write(cpu.AbsoluteAddress, cpu.A);
        return false;
    }
}