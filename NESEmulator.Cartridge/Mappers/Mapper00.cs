namespace NESEmulator.Cartridge.Mappers;

public class Mapper00 : IMapper
{
    int ProgramBanks { get; init; }
    int CharacterBanks { get; init; }

    public Mapper00(int programBanks, int characterBanks)
    {
        ProgramBanks = programBanks;
        CharacterBanks = characterBanks;
    }

    public ushort MapCPUReadAddress(ushort address)
    {
        return (ushort)(address & (ProgramBanks > 1 ? 0x7FFF : 0x3FFF));
    }

    public ushort MapCPUWriteAddress(out bool shouldUpdateROM, ushort address, byte data)
    {
        shouldUpdateROM = true;
        return (ushort)(address & (ProgramBanks > 1 ? 0x7FFF : 0x3FFF));
    }

    public ushort MapPPUReadAddress(ushort address)
    {
        return address;
    }

    public ushort MapPPUWriteAddress(out bool shouldUpdateROM, ushort address, byte data)
    {
        shouldUpdateROM = CharacterBanks == 0;
        return address;
    }
}