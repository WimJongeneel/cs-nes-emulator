using NESEmulator.Bus;

namespace NESEmulator.Cartridge;

public class CPUAdapter : IBusDevice
{
    Cartridge Cartridge { get; init; }

    public CPUAdapter(Cartridge cartridge)
    {
        Cartridge = cartridge ?? throw new ArgumentNullException(nameof(cartridge));
    }

    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x8000 && address <= 0xFFFF;
    }

    public byte Read(ushort address)
    {
        return Cartridge.ProgramMemory[Cartridge.Mapper.MapCPUReadAddress(address)];
    }

    public void Write(ushort address, byte data)
    {
        var mapped = Cartridge.Mapper.MapCPUWriteAddress(out bool shouldUpdateROM, address, data);
        if(shouldUpdateROM) Cartridge.ProgramMemory[mapped] = data;
    }
}