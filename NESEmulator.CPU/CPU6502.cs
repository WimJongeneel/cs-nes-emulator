using NESEmulator.Bus;
using NESEmulator.CPU.OPCodes;
using NESEmulator.CPU.Instructions;
using NESEmulator.CPU.AddressingModes;

namespace NESEmulator.CPU;

public class CPU6502
{
    public IBus Bus { get; init; }
    InstructionTable InstructionTable { get; } = new();

    public CPU6502(IBus bus)
    {
        Bus = bus ?? throw new ArgumentNullException();
    }

    #region CPU registers as present on the actual hardware

    public byte A { get; set; }
    public byte X { get; set; }
    public byte Y { get; set; }
    public byte StackPointer { get; set; }
    public short ProgramCounter { get; set; }
    public byte Status { get; set; }

    #endregion

    #region Internal CPU state for the emulation

    public short AbsoluteAddress { get; set; }
    public short RelativeAddressOffset { get; set; }
    public byte FetchCache { get; set; }
    public IOPCode OPCode { get; set; } = new NOP_NoOp();
    public IAddressingMode AddressingMode { get; set; } = new IMP_Implied();
    public int Cycles { get; set; }

    #endregion

    public bool GetStatusFlag(CPUFlag flag)
    {
        return (Status & (byte)flag) > 0;
    }

    public void SetStatusFlag(CPUFlag flag, bool status)
    {
        if (status) Status |= (byte)flag;
        else Status &= (byte)~(byte)flag;
    }

    public void ClockSingleTick()
    {
        if(Cycles > 0)
        {
            Cycles--;
            return;
        }

        SetStatusFlag(CPUFlag.U, true);

        (OPCode, AddressingMode, Cycles) = InstructionTable.LookUp(Bus.Read(ProgramCounter));

        ProgramCounter++;

        var needExtraCycle1 = AddressingMode.Execute(this);
        var needExtraCycle2 = OPCode.Execute(this);

        if(needExtraCycle1 && needExtraCycle2) Cycles++;
    }

    public byte FetchMemory()
    {
        if(!AddressingMode.SkipFetch)
            FetchCache = Bus.Read(AbsoluteAddress);

        return FetchCache;
    }

}