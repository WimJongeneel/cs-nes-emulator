using NESEmulator.Bus;

namespace NESEmulator.Memory;

public class NameTables : IBusDevice
{
    byte[][] Data = new byte[][]
    {
        new byte[1024],
        new byte[1024],
    };

    public enum MirrorModeEnum
    {
        Horizontal,
        Vertical,
        OneScreenLow,
        OneScreenHigh
    }

    public MirrorModeEnum MirrorMode { get; set; }

    // TODO: correct addressing ranges and address mapping / mirroring
    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x2000 && address <= 0x3EFF;
    }

    public byte Read(ushort address)
    {
        if(MirrorMode == MirrorModeEnum.Vertical)
        {
            return address switch
            {
                >= 0x0000 and <= 0x03FF => Data[0][address & 0x03FF],
                >= 0x0400 and <= 0x07FF => Data[1][address & 0x03FF],
                >= 0x0800 and <= 0x0BFF => Data[0][address & 0x03FF],
                >= 0x0C00 and <= 0x0FFF => Data[1][address & 0x03FF],
                _ => 0
            };
        }
        else if(MirrorMode == MirrorModeEnum.Horizontal)
        {
            return address switch
            {
                >= 0x0000 and <= 0x03FF => Data[0][address & 0x03FF],
                >= 0x0400 and <= 0x07FF => Data[0][address & 0x03FF],
                >= 0x0800 and <= 0x0BFF => Data[1][address & 0x03FF],
                >= 0x0C00 and <= 0x0FFF => Data[1][address & 0x03FF],
                _ => 0
            };
        }

        return 0;
    }

    public void Write(ushort address, byte data)
    {
        if(MirrorMode == MirrorModeEnum.Vertical)
        {
            switch(address)
            {
                case >= 0x0000 and <= 0x03FF:
                    Data[0][address & 0x03FF] = data;
                    return;
                case >= 0x0400 and <= 0x07FF:
                    Data[1][address & 0x03FF] = data;
                    return;
                case 0x0800 and <= 0x0BFF:
                    Data[0][address & 0x03FF] = data;
                    return;
                case >= 0x0C00 and <= 0x0FFF:
                    Data[1][address & 0x03FF] = data;
                    return;
            };
        }
        else if(MirrorMode == MirrorModeEnum.Horizontal)
        {
            switch(address)
            {
                case >= 0x0000 and <= 0x03FF:
                    Data[0][address & 0x03FF] = data;
                    return;
                case >= 0x0400 and <= 0x07FF:
                    Data[0][address & 0x03FF] = data;
                    return;
                case >= 0x0800 and <= 0x0BFF:
                    Data[1][address & 0x03FF] = data;
                    return;
                case >= 0x0C00 and <= 0x0FFF:
                    Data[1][address & 0x03FF] = data;
                    return;
            };
        }
    }
}