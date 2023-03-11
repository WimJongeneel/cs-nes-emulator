using NESEmulator.Bus;

namespace NESEmulator.Cartridge;

public class PPUAdapter : IBusDevice
{
    Cartridge Cartridge { get; init; }

    public PPUAdapter(Cartridge cartridge)
    {
        Cartridge = cartridge ?? throw new ArgumentNullException(nameof(cartridge));
    }

    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x0000 && address <= 0x1FFF;
    }

    public byte read(ushort address)
    {
        return Cartridge.CharacterMemory[Cartridge.Mapper.MapPPUReadAddress(address)];
    }

    public void write(ushort address, byte data)
    {
        var mapped = Cartridge.Mapper.MapPPUWriteAddress(out bool shouldUpdateROM, address, data);
        if(shouldUpdateROM) Cartridge.CharacterMemory[mapped] = data;
    }
}