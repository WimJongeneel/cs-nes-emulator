using NESEmulator.CPU;
using NESEmulator.Memory;

namespace NESEmulator.Bus;

public class CpuBus : IBus
{

    public CPU6502 CPU { get; init; }
    private List<IBusDevice> BusDevices { get; } = new()
    {
        new RAM()
    };

    public CpuBus()
    {
        CPU = new CPU6502(this);
    }

    public byte Read(short address, bool _readonly = false)
    {
        var device = BusDevices.FirstOrDefault(d => d.IsInAddressRange(address));
        if(device is not null) return device.read(address);
        return 0x00;
    }

    public void write(short address, byte data)
    {
        var device = BusDevices.FirstOrDefault(d => d.IsInAddressRange(address));
        if(device is not null) device.write(address, data);
    }
}