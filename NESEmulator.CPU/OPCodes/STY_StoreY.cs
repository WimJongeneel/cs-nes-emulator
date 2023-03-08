namespace NESEmulator.CPU.OPCodes;

public class STY_StoreY : IOPCode
{
    public string Name => nameof(STY_StoreY);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.write(cpu.AbsoluteAddress, cpu.Y);
        return false;
    }
}