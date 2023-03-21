namespace NESEmulator.PPU.Registers;

public record BackgroundShifter
{
    public ushort PatternLow { get; set; }
    public ushort PatternHigh { get; set; }
    public ushort AttributeLow { get; set; }
    public ushort AttributeHigh { get; set; }

    public void Shift()
    {
        PatternLow <<= 1;
        PatternHigh <<= 1;
        AttributeLow <<= 1;
        AttributeHigh <<= 1;
    }
}