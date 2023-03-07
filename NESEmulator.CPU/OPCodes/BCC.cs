namespace NESEmulator.CPU.OPCodes;

public class BCC : IOPCode
{
    public string Name => nameof(BCC);

    public bool Execute(CPU6502 cpu)
    {
        if(cpu.GetStatusFlag(CPUFlag.C)) return false;

        cpu.Cycles++;
        cpu.AbsoluteAddress = (short)(cpu.ProgramCounter + cpu.RelativeAddressOffset);

        if((cpu.AbsoluteAddress & 0xFF00) != (cpu.ProgramCounter & 0xFF00))
            cpu.Cycles++;

        cpu.ProgramCounter = cpu.AbsoluteAddress;

        return false;
    }
}