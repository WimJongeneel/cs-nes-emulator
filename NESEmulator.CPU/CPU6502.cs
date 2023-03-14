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
    public ushort ProgramCounter { get; set; }
    public byte Status { get; set; }

    #endregion

    #region Internal CPU state for the emulation

    public ushort AbsoluteAddress { get; set; }
    public ushort RelativeAddressOffset { get; set; }
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

    public bool IsComplete() => Cycles == 0;

    public byte FetchMemory()
    {
        if(!AddressingMode.SkipFetch)
            FetchCache = Bus.Read(AbsoluteAddress);

        return FetchCache;
    }

    public void NonMaskableInterrupt()
    {
        Bus.Write((ushort)(0x0100 + StackPointer--), (byte)((ProgramCounter >> 8) & 0x00F));
        Bus.Write((ushort)(0x0100 + StackPointer--), (byte)(ProgramCounter & 0x00F));
        
        SetStatusFlag(CPUFlag.B, false);
        SetStatusFlag(CPUFlag.U, true);
        SetStatusFlag(CPUFlag.I, true);

        Bus.Write((ushort)(0x0100 + StackPointer--), Status);

        AbsoluteAddress = 0xFFFA;
        ushort low = Bus.Read(AbsoluteAddress);
        ushort high = Bus.Read((ushort)(AbsoluteAddress + 1));
        ProgramCounter = (ushort)((high << 8) | low);

        Cycles = 8;
    }

    public void RequestInterrupt()
    {
        Bus.Write((ushort)(0x0100 + StackPointer--), (byte)((ProgramCounter >> 8) & 0x00F));
        Bus.Write((ushort)(0x0100 + StackPointer--), (byte)(ProgramCounter & 0x00F));
        
        SetStatusFlag(CPUFlag.B, false);
        SetStatusFlag(CPUFlag.U, true);
        SetStatusFlag(CPUFlag.I, true);

        Bus.Write((ushort)(0x0100 + StackPointer--), Status);

        AbsoluteAddress = 0xFFFE;
        ushort low = Bus.Read(AbsoluteAddress);
        ushort high = Bus.Read((ushort)(AbsoluteAddress + 1));
        ProgramCounter = (ushort)((high << 8) | low);

        Cycles = 7;
    }
}