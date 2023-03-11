namespace NESEmulator.CPU.OPCodes;

public class BVC_BranchIfOverflowClear : IOPCode
{
    public string Name => nameof(BVC_BranchIfOverflowClear);

    public bool Execute(CPU6502 cpu)
    {
        if(cpu.GetStatusFlag(CPUFlag.V)) return false;

        cpu.Cycles++;
        cpu.AbsoluteAddress = (ushort)(cpu.ProgramCounter + cpu.RelativeAddressOffset);

        if((cpu.AbsoluteAddress & 0xFF00) != (cpu.ProgramCounter & 0xFF00))
            cpu.Cycles++;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}