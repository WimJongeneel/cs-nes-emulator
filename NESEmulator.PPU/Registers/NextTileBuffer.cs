namespace NESEmulator.PPU.Registers;

public record NextTileBuffer
{
    public byte NextBackgroundTileId { get; set; }
    public byte NextBackgroundTileAttribute { get; set; }
    public byte NextBackgroundTileLSB { get; set; }
    public byte NextBackgroundTileMSB { get; set; }
}