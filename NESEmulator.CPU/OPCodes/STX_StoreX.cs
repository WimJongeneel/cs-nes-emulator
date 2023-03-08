namespace NESEmulator.CPU.OPCodes;

public class STX_StoreX : IOPCode
{
    public string Name => nameof(STX_StoreX);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.write(cpu.AbsoluteAddress, cpu.X);
        return false;
    }
}