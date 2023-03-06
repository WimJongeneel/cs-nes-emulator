using NesEmulator.Bus;

namespace NesEmulator.CPU;

public class CPU6502
{
    public IBus Bus { get; init; }

    public CPU6502(IBus bus)
    {
        Bus = bus;
    }

    #region CPU registers as on the actual hardware

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
    public short FetchCache { get; set; }

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

    

}