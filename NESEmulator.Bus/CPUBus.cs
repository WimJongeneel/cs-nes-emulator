using NESEmulator.CPU;
using NESEmulator.Memory;
using NESEmulator.Controller;
using NESEmulator.PPU;
using NESEmulator.Cartridge;

namespace NESEmulator.Bus;

public class CPUBus : IBus
{

    public CPU6502 CPU { get; init; }
    public PPU2C02 PPU { get; } = new(new PPUBus());
    public List<IBusDevice> BusDevices { get; } = new()
    {
        new RAM(),
        new NESKeyboardController(),
    };

    public CPUBus()
    {
        CPU = new CPU6502(this);
        BusDevices.Add(PPU);
    }

    public void InsertCartridge(CartridgeReader cartridge)
    {
        BusDevices.Insert(0, cartridge.GetCPUAdapter());
        PPU.Bus.BusDevices.Insert(0, cartridge.GetPPUAdapter());
    }

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

    public void ClockFullInstruction()
    {
        do
        {
            CPU.ClockSingleTick();
            // 3 PPU ticks per CPU tick
            PPU.ClockSingleTick();
            PPU.ClockSingleTick();
            PPU.ClockSingleTick();
        }
        while(!CPU.IsComplete());
    }
}