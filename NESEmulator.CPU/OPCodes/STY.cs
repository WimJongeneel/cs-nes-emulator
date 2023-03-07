namespace NESEmulator.CPU.OPCodes;

public class STY : IOPCode
{
    public string Name => nameof(STY);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.write(cpu.AbsoluteAddress, cpu.Y);
        return false;
    }
}