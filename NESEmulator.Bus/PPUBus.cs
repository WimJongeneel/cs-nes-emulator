namespace NESEmulator.Bus;

public class PPUBus : IBus
{
    private List<IBusDevice> BusDevices { get; } = new();

    public byte Read(ushort address, bool _readonly = false)
    {
        var device = BusDevices.FirstOrDefault(d => d.IsInAddressRange(address));
        if(device is not null) return device.read(address);
        return 0x00;
    }

    public void Write(ushort address, byte data)
    {
        var device = BusDevices.FirstOrDefault(d => d.IsInAddressRange(address));
        if(device is not null) device.write(address, data);
    }
}