namespace NESEmulator.CPU.OPCodes;

public class STA_StoreA : IOPCode
{
    public string Name => nameof(STA_StoreA);

    public bool Execute(CPU6502 cpu)
    {
        cpu.Bus.write(cpu.AbsoluteAddress, cpu.A);
        return false;
    }
}