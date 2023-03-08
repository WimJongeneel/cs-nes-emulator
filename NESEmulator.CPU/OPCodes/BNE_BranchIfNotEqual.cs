namespace NESEmulator.CPU.OPCodes;

public class BNE_BranchIfNotEqual : IOPCode
{
    public string Name => nameof(BNE_BranchIfNotEqual);

    public bool Execute(CPU6502 cpu)
    {
        if(cpu.GetStatusFlag(CPUFlag.Z)) return false;

        cpu.Cycles++;
        cpu.AbsoluteAddress = (short)(cpu.ProgramCounter + cpu.RelativeAddressOffset);

        if((cpu.AbsoluteAddress & 0xFF00) != (cpu.ProgramCounter & 0xFF00))
            cpu.Cycles++;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}