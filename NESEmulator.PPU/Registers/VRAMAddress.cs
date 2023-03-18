namespace NESEmulator.PPU.Registers;

public record VRAMAddress
{
    public uint CoarseX 
    { 
        get => ReadBits(Value, 11, 5);
        set => Value = SetBits(Value, value, 11, 5);
    }

    public uint CoarseY
    { 
        get => ReadBits(Value, 6, 5);
        set => Value = SetBits(Value, value, 6, 5);
    }

    public uint NametableY
    { 
        get => ReadBits(Value, 5, 1);
        set => Value = SetBits(Value, value, 5, 1);
    }

    public uint NametableX
    { 
        get => ReadBits(Value, 4, 1);
        set => Value = SetBits(Value, value, 4, 1);
    }

    public uint FineY
    { 
        get => ReadBits(Value, 1, 3);
        set => Value = SetBits(Value, value, 1, 4);
    }

    public uint Value { get; set; }

    static uint SetBits(uint word, uint value, int pos, int size)
    {
        uint mask = ((((uint)1) << size) - 1) << pos;
        word &= ~mask;
        word |= (value << pos) & mask;
        return word;
    }

    static uint ReadBits(uint word, int pos, int size)
    {
        uint mask = ((((uint)1) << size) - 1) << pos;
        return (word & mask) >> pos;
    }
}