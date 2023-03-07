namespace NESEmulator.CPU.OPCodes;

public class STX : IOPCode
{
    public string Name => nameof(STX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.write(cpu.AbsoluteAddress, cpu.X);
        return false;
    }
}