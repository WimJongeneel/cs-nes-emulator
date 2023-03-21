using NESEmulator.Bus;
using NESEmulator.PPU.Registers;

namespace NESEmulator.PPU;

public class PPU2C02 : IBusDevice
{
    public IBus Bus { get; init; }

    #region Registers as present on the actual hardware
    PPUStatusRegister Status { get; } = new();
    PPUMaskRegister Mask { get; } = new();
    PPUControlRegister Control { get; } = new();
    #endregion

    #region Internal state for emulating reading addresses and data
    bool WriteAddressLatch { get; set; }
    byte ReadBuffer { get; set; }
    #endregion

    #region Internal state for rendering
    int ScanLineY { get; set; }
    int CycleX { get; set; }
    bool IsFrameComplete { get; set; }
    public bool RequestingNonMaskableInterrupt { get; set; }
    byte FineXScrolling { get; set; }
    VRAMAddress VRAMAddress { get; } = new();
    VRAMAddress TRAMAddress { get; } = new();
    NextTileBuffer NextTileBuffer { get; set; } = new();
    BackgroundShifter BackgroundShifter { get; set; } = new();
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

        var isVisibleScanline = ScanLineY > -1 && ScanLineY < 240;
        if(isVisibleScanline)
        {
            var shouldExtractTileData = (CycleX >= 2 && CycleX < 258) || (CycleX >= 321 && CycleX < 338);
            if(shouldExtractTileData)
            {
                UpdateShifters();
                // This logic loads various bits of the data to render the next tile during the cycles for rendering current tile
                // The bitwise logic here is wild, but just mimics the hardware and memory layout of the NES
                switch((CycleX - 1) % 8)
                {
                    case 0:
                        LoadBackgroundShifters();
                        NextTileBuffer.NextBackgroundTileId = Bus.Read((ushort)(0x2000 | (VRAMAddress.Value & 0x0FFF)));
                        break;
                    case 2:
                        NextTileBuffer.NextBackgroundTileAttribute = Bus.Read((ushort)(
                            0x23C0 | (VRAMAddress.NametableY << 11) | (VRAMAddress.NametableX << 10) | ((VRAMAddress.CoarseY >> 2) << 3) | (VRAMAddress.CoarseX >> 2)
                        ));
                        if((VRAMAddress.CoarseY & 0x02) > 0)
                        {
                            NextTileBuffer.NextBackgroundTileAttribute >>= 4;
                        }
                        if((VRAMAddress.CoarseX & 0x02) > 0)
                        {
                            NextTileBuffer.NextBackgroundTileAttribute >>= 2;
                        }
                        NextTileBuffer.NextBackgroundTileAttribute &= 0x03;
                        break;
                    case 4:
                        NextTileBuffer.NextBackgroundTileLSB = Bus.Read((ushort)(
                            ((Control.PatternBackground ? 1 : 0) << 12) + (NextTileBuffer.NextBackgroundTileId << 4) + VRAMAddress.FineY
                        ));
                        break;
                    case 6:
                    NextTileBuffer.NextBackgroundTileMSB = Bus.Read((ushort)(
                            ((Control.PatternBackground ? 1 : 0) << 12) + (NextTileBuffer.NextBackgroundTileId << 4) + VRAMAddress.FineY + 8
                        ));
                        break;
                    case 7:
                        IncrementScrollX();
                        break;
                }
            }

            var isEndOfScanline = CycleX == 256;
            if(isEndOfScanline)
            {
                IncrementScrollY();
            }

            var isAfterEndOfScanline = CycleX == 257;
            if(isAfterEndOfScanline)
            {
                LoadBackgroundShifters();
                ResetXAddress();
            }

            var isNonVisibleScanline = ScanLineY == -1 && CycleX >= 280 && CycleX < 305;
            if(isNonVisibleScanline)
            {
                ResetYAddress();
            }
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
    }

    void UpdateShifters()
    {
        if(Mask.RenderBackground)
        {
            BackgroundShifter.Shift();
        }
    }

    void IncrementScrollY()
    {
        if(Mask.RenderBackground || Mask.RenderSprites)
        {
            VRAMAddress.IncrementScrollY();
        }
    }

    public void IncrementScrollX()
    {
        if(Mask.RenderBackground || Mask.RenderSprites)
        {
            VRAMAddress.IncrementScrollX();
        }
    }

    void ResetXAddress()
    {
        if(Mask.RenderBackground || Mask.RenderSprites)
        {
            VRAMAddress.NametableX = TRAMAddress.NametableX;
            VRAMAddress.CoarseX = TRAMAddress.CoarseX;
        }
    }

    void ResetYAddress()
    {
        if(Mask.RenderBackground || Mask.RenderSprites)
        {
            VRAMAddress.NametableY = TRAMAddress.NametableY;
            VRAMAddress.CoarseY = TRAMAddress.CoarseY;
            VRAMAddress.FineY = TRAMAddress.FineY;
        }
    }

    void LoadBackgroundShifters()
    {
        BackgroundShifter.PatternLow = (ushort)((BackgroundShifter.PatternLow & 0xFF00) | NextTileBuffer.NextBackgroundTileLSB);
        BackgroundShifter.PatternHigh= (ushort)((BackgroundShifter.PatternHigh & 0xFF00) | NextTileBuffer.NextBackgroundTileMSB);

        BackgroundShifter.AttributeLow = (ushort)((BackgroundShifter.AttributeLow & 0xFF00) | ((NextTileBuffer.NextBackgroundTileAttribute & 0b01) > 0 ? 0xFF : 0x00));
        BackgroundShifter.AttributeHigh = (ushort)((BackgroundShifter.AttributeHigh & 0xFF00) | ((NextTileBuffer.NextBackgroundTileAttribute & 0b10) > 0 ? 0xFF : 0x00));
    }

    void UpdateBackgroundShifters()
    {
        if(!Mask.RenderBackground) return;

        BackgroundShifter.PatternLow <<= 1;
        BackgroundShifter.PatternHigh <<= 1;

        BackgroundShifter.AttributeLow <<= 1;
        BackgroundShifter.AttributeHigh <<= 1;
    }

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
                TRAMAddress.NametableX = Control.NametableX ? 1u : 0u;
                TRAMAddress.NametableY = Control.NametableY ? 1u : 0u;
                break;
            case 1:
                Mask.Value = data;
                break;
            case 5:
                if(WriteAddressLatch)
                {
                    TRAMAddress.FineY = (uint)(data & 0x07);
                    TRAMAddress.CoarseY = (uint)(data >> 3);
                    WriteAddressLatch = false;
                }
                else
                {
                    FineXScrolling = (byte)(data & 0x07);
                    TRAMAddress.CoarseX = (uint)(data >> 3);
                    WriteAddressLatch = true;
                }
                break;
            case 6:
                if(WriteAddressLatch)
                {
                    TRAMAddress.Value = (ushort)((TRAMAddress.Value & 0xFF00) | data);
                    WriteAddressLatch = false;
                }
                else
                {
                    TRAMAddress.Value = (ushort)((TRAMAddress.Value & 0x00FF) | data);
                    VRAMAddress.Value = TRAMAddress.Value;
                    WriteAddressLatch = true;
                }
                break;
            case 7:
                Bus.Write((ushort)VRAMAddress.Value, data);
                VRAMAddress.Value += (ushort)(Control.IncrementMode ? 32 : 1);
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
                ReadBuffer = Bus.Read((ushort)VRAMAddress.Value);
                if(VRAMAddress.Value > 0x3F00) result = ReadBuffer;
                VRAMAddress.Value += (ushort)(Control.IncrementMode ? 32 : 1);
                break;
        }

        return result;
    }
}