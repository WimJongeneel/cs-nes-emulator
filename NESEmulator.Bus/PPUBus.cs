using NESEmulator.Memory;

namespace NESEmulator.Bus;

public class PPUBus : IBus
{
    public List<IBusDevice> BusDevices { get; } = new()
    {
        new NameTables(),
        new PaletTable()
    };

    public byte Read(ushort address, bool _readonly = false)
    {
        var device = BusDevices.FirstOrDefault(d => d.IsInAddressRange(address));
        if(device is not null) return device.Read(address);
        return 0x00;
    }

    public void Write(ushort address, byte data)
    {
        var device = BusDevices.FirstOrDefault(d => d.IsInAddressRange(address));
        if(device is not null) device.Write(address, data);
    }
}