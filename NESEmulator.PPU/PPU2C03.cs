using NESEmulator.Bus;
using NESEmulator.PPU.Registers;

namespace NESEmulator.PPU;

public class PPU2C02 : IBusDevice
{
    public IBus Bus { get; init; }

    #region Registers as present on the actual hardware

    PPUStatusRegister Status { get; init; } = new PPUStatusRegister();
    PPUMaskRegister Mask { get; init; } = new PPUMaskRegister();
    PPUControlRegister Control { get; init; } = new PPUControlRegister();

    #endregion

    #region Internal state for emulating reading addresses and data

    bool WriteAddressLatch { get; set; }
    byte ReadBuffer { get; set; }
    ushort Address { get; set; }

    #endregion

    #region Internal state for rendering

    int ScanLineY { get; set; }
    int CycleX { get; set; }
    bool IsFrameComplete { get; set; }
    public bool RequestingNonMaskableInterrupt { get; set; }

    #endregion

    public PPU2C02(IBus bus)
    {
        Bus = bus ?? throw new ArgumentNullException();
    }

    public void ClockSingleTick()
    {
        var IsFirstCycleOfNewFrame = ScanLineY == -1 && CycleX == 1;
        if (IsFirstCycleOfNewFrame)
        {
            Status.VerticalBlank = false;
            IsFrameComplete = false;
        }

        var IsEndOfVisibleFrame = ScanLineY == 241 && CycleX == 1;
        if (IsEndOfVisibleFrame)
        {
            Status.VerticalBlank = true;
            if(Control.EnableNMI)
            {
                RequestingNonMaskableInterrupt = true;
            }
        }

        MoveNextTick();

        void MoveNextTick()
        {
            CycleX++;
            if (CycleX >= 341)
            {
                CycleX = 0;
                ScanLineY++;
                if (ScanLineY >= 261)
                {
                    ScanLineY = -1;
                    IsFrameComplete = true;
                }
            }
        }
    }

    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x2000 && address <= 0x3FFF;
    }

    public void Write(ushort address, byte data)
    {
        switch(address & 0x0007)
        {
            case 0: 
                Control.Value = data;
                break;
            case 1:
                Mask.Value = data;
                break;
            case 6:
                if(WriteAddressLatch)
                {
                    Address = (ushort)((Address & 0xFF00) | data);
                    WriteAddressLatch = false;
                }
                else
                {
                    Address = (ushort)((Address & 0x00FF) | data);
                    WriteAddressLatch = true;
                }
                break;
            case 7:
                Bus.Write(Address, data);
                Address += (ushort)(Control.IncrementMode ? 32 : 1);
                break;
        }
    }

    public byte Read(ushort address)
    {
        byte result = 0;
        switch(address & 0x0007)
        {
            case 2:
                result = Status.Value;
                Status.VerticalBlank = false;
                WriteAddressLatch = false;
                break;
            case 7: 
                result = ReadBuffer;
                ReadBuffer = Bus.Read(Address);
                if(Address > 0x3F00) result = ReadBuffer;
                Address += (ushort)(Control.IncrementMode ? 32 : 1);
                break;
        }

        return result;
    }
}