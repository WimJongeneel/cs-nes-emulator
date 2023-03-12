namespace NESEmulator.PPU.Registers;

public record PPUStatusRegister
{
    public bool SpriteOverflow 
    { 
        get => (Value & (1 << 5)) > 0;
        set
        {
            byte mask = (byte)(1 << 5); 
            if (value) Value |= (mask);
            else Value &= (byte)~mask;
        }
    }

    public bool SpriteZeroHit
    { 
        get => (Value & (1 << 6)) > 0;
        set
        {
            byte mask = (byte)(1 << 6); 
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool VerticalBlank
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