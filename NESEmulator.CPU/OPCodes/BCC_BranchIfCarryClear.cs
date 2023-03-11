namespace NESEmulator.CPU.OPCodes;

public class BCC_BranchIfCarryClear : IOPCode
{
    public string Name => nameof(BCC_BranchIfCarryClear);

    public bool Execute(CPU6502 cpu)
    {
        if(cpu.GetStatusFlag(CPUFlag.C)) return false;

        cpu.Cycles++;
        cpu.AbsoluteAddress = (ushort)(cpu.ProgramCounter + cpu.RelativeAddressOffset);

        if((cpu.AbsoluteAddress & 0xFF00) != (cpu.ProgramCounter & 0xFF00))
            cpu.Cycles++;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}