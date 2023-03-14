using NESEmulator.Cartridge.Mappers;
using static NESEmulator.Memory.NameTables;

namespace NESEmulator.Cartridge;

public static class CartridgeReader
{
    record Header
    {
        public byte ProgramROMChunks => Data[4];
        public byte CharacterROMChunks => Data[5];
        public byte Mapper1 => Data[6];
        public byte Mapper2 => Data[7];
        public byte ProgramRAMChunks => Data[8];
        public byte TVSystem1 => Data[9];
        public byte TVSystem2 => Data[10];
        public byte[] Data { get; set; } = new byte[16];
    }

    public static Cartridge Read(string path)
    {
        using var fs = File.OpenRead(path);
        using var br = new BinaryReader(fs);

        var header = new Header
        {
            Data = br.ReadBytes(16)
        };

        if((header.Mapper1 & 0x04) > 0)
        {
            br.ReadBytes(512);
        }

        return new Cartridge(
            new Mapper00(header.ProgramROMChunks, header.CharacterROMChunks),
            br.ReadBytes(header.ProgramROMChunks * 16384),
            br.ReadBytes(header.CharacterROMChunks * 8192),
            ((byte)(header.Mapper1 & 0x01) ) > 0 ? MirrorModeEnum.Vertical : MirrorModeEnum.Horizontal
        );
    }
}