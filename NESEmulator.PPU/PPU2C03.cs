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
    VRAMAddress VRAMAddress { get; } = new();
    VRAMAddress TRAMAddress { get; } = new();
    byte FineXScrolling { get; set; }
    byte NextBackgroundTileId { get; set; }
    byte NextBackgroundTileAttribute { get; set; }
    byte NextBackgroundTileLSB { get; set; }
    byte NextBackgroundTileMSB { get; set; }

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
                switch((CycleX - 1) % 8)
                {
                    // Fetching of tiles and attributes goes here
                    case 0:
                        break;
                    case 2:
                        break;
                    case 4:
                        break;
                    case 6:
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

    void IncrementScrollX()
    {
        if(Mask.RenderBackground || Mask.RenderSprites)
        {
            if(VRAMAddress.CoarseX == 31)
            {
                VRAMAddress.CoarseX = 0;
                VRAMAddress.NametableX = ~VRAMAddress.NametableX;
            }
            else
            {
                VRAMAddress.CoarseX++;
            }
        }
    }

    void IncrementScrollY()
    {
        if(Mask.RenderBackground || Mask.RenderSprites)
        {
            if(VRAMAddress.FineY < 7)
            {
                VRAMAddress.FineY++;
            }
            else
            {
                VRAMAddress.FineY = 0;
                if(VRAMAddress.CoarseY == 29)
                {
                    VRAMAddress.CoarseY = 0;
                    VRAMAddress.NametableY = ~VRAMAddress.NametableY;
                }
                else if(VRAMAddress.CoarseY == 31)
                {
                    VRAMAddress.CoarseY = 0;
                }
                else
                {
                    VRAMAddress.CoarseY++;
                }
            }
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