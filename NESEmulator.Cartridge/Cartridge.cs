using NESEmulator.Bus;
using NESEmulator.Cartridge.Mappers;

namespace NESEmulator.Cartridge;

public class Cartridge
{
    public byte[] ProgramMemory { get; init; }
    public byte[] CharacterMemory { get; init; }
    public IMapper Mapper { get; init; }
    public IBusDevice PPUAdapter { get; init; }
    public IBusDevice CPUAdapter { get; init; }

    public Cartridge(IMapper mapper, byte[] programMemory, byte[] characterMemory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        PPUAdapter = new PPUAdapter(this);
        CPUAdapter = new CPUAdapter(this);
        ProgramMemory = programMemory ?? Array.Empty<byte>();
        CharacterMemory = characterMemory ?? Array.Empty<byte>();
    }
}