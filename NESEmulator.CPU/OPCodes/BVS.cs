namespace NESEmulator.CPU.OPCodes;

public class BVS : IOPCode
{
    public string Name => nameof(BVS);

    public bool Execute(CPU6502 cpu)
    {
        if(!cpu.GetStatusFlag(CPUFlag.V)) return false;

        cpu.Cycles++;
        cpu.AbsoluteAddress = (short)(cpu.ProgramCounter + cpu.RelativeAddressOffset);

        if((cpu.AbsoluteAddress & 0xFF00) != (cpu.ProgramCounter & 0xFF00))
            cpu.Cycles++;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}