namespace NESEmulator.PPU.Registers;

public record PPUControlRegister
{
    public bool NametableX 
    { 
        get => (Value & (1 << 0)) > 0;
        set
        {
            byte mask = (byte)(1 << 0);
            if (value) Value |= (mask);
            else Value &= (byte)~mask;
        }
    }

    public bool NametableY
    { 
        get => (Value & (1 << 1)) > 0;
        set
        {
            byte mask = (byte)(1 << 1);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool IncrementMode
    { 
        get => (Value & (1 << 2)) > 0;
        set
        {
            byte mask = (byte)(1 << 2);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool PatternSprite
    { 
        get => (Value & (1 << 3)) > 0;
        set
        {
            byte mask = (byte)(1 << 3);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool PatternBackground
    { 
        get => (Value & (1 << 4)) > 0;
        set
        {
            byte mask = (byte)(1 << 4);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool SpriteSize
    { 
        get => (Value & (1 << 5)) > 0;
        set
        {
            byte mask = (byte)(1 << 5);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool SlaveMode
    { 
        get => (Value & (1 << 6)) > 0;
        set
        {
            byte mask = (byte)(1 << 6);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool EnableNMI
    { 
        get => (Value & (1 << 7)) > 0;
        set
        {
            byte mask = (byte)(1 << 7);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public byte Value { get; set; }
}