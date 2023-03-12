namespace NESEmulator.PPU.Registers;

public record PPUMaskRegister
{
    public bool GrayScale 
    { 
        get => (Value & (1 << 0)) > 0;
        set
        {
            byte mask = (byte)(1 << 0);
            if (value) Value |= (mask);
            else Value &= (byte)~mask;
        }
    }

    public bool RenderBackgroundLeft
    { 
        get => (Value & (1 << 1)) > 0;
        set
        {
            byte mask = (byte)(1 << 1);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool RenderSpritesLeft
    { 
        get => (Value & (1 << 2)) > 0;
        set
        {
            byte mask = (byte)(1 << 2);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool RenderBackground
    { 
        get => (Value & (1 << 3)) > 0;
        set
        {
            byte mask = (byte)(1 << 3);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool RenderSprites
    { 
        get => (Value & (1 << 4)) > 0;
        set
        {
            byte mask = (byte)(1 << 4);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool EnhanceRed
    { 
        get => (Value & (1 << 5)) > 0;
        set
        {
            byte mask = (byte)(1 << 5);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool EnhanceGreen
    { 
        get => (Value & (1 << 6)) > 0;
        set
        {
            byte mask = (byte)(1 << 6);
            if (value) Value |= mask;
            else Value &= (byte)~mask;
        }
    }

    public bool EnhanceBlue
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