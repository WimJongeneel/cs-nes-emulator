using NESEmulator.Bus;
using NESEmulator.Cartridge.Mappers;

namespace NESEmulator.Cartridge;

public class Cartridge
{
    public byte[] ProgramMemory { get; init; } = Array.Empty<byte>();
    public byte[] CharacterMemory { get; init; } = Array.Empty<byte>();
    public IMapper Mapper { get; init; }

    public Cartridge(IMapper mapper)
    {
        Mapper = mapper;
    }

    public IBusDevice GetPPUAdapter()
    {
        return new PPUAdapter(this);
    }

    public IBusDevice GetCPUAdapter()
    {
        return new CPUAdapter(this);
    }
}