using NESEmulator.Bus;
using NESEmulator.PPU.Registers;

namespace NESEmulator.PPU;

public class PPU2C02 : IBusDevice
{
    public IBus Bus { get; init; }
    PPUStatusRegister Status { get; init; } = new PPUStatusRegister();
    PPUMaskRegister Mask { get; init; } = new PPUMaskRegister();
    PPUControlRegister Control { get; init; } = new PPUControlRegister();
    bool WriteAddressLatch { get; set; }
    byte ReadBuffer { get; set; }
    ushort Address { get; set; }

    public PPU2C02(IBus bus)
    {
        Bus = bus ?? throw new ArgumentNullException();
    }

    public void ClockSingleTick()
    {

    }

    public bool IsInAddressRange(ushort address)
    {
        return address >= 0x2000 && address <= 0x3FFF;
    }

    public void Write(ushort address, byte data)
    {
        switch(address & 0x0007)
        {
            case 0: 
                Control.Value = data;
                break;
            case 1:
                Mask.Value = data;
                break;
            case 6:
                if(WriteAddressLatch)
                {
                    Address = (ushort)((Address & 0xFF00) | data);
                    WriteAddressLatch = false;
                }
                else
                {
                    Address = (ushort)((Address & 0x00FF) | data);
                    WriteAddressLatch = true;
                }
                break;
            case 7:
                Bus.Write(Address, data);
                Address++;
                break;
        }
    }

    public byte Read(ushort address)
    {
        byte result = 0;
        switch(address & 0x0007)
        {
            case 2:
                result = Status.Value;
                Status.VerticalBlank = false;
                WriteAddressLatch = false;
                break;
            case 7: 
                result = ReadBuffer;
                ReadBuffer = Bus.Read(Address);
                if(Address > 0x3F00) result = ReadBuffer;
                Address++;
                break;
        }

        return result;
    }
}