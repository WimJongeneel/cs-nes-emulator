namespace NESEmulator.Cartridge.Mappers;

public interface IMapper
{
    ushort MapCPUWriteAddress(out bool shouldUpdateROM, ushort address, byte data);
    ushort MapCPUReadAddress(ushort address);
    ushort MapPPUWriteAddress(out bool shouldUpdateROM, ushort address, byte data);
    ushort MapPPUReadAddress(ushort address);
}