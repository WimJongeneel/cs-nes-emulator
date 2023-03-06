namespace NesEmulator.CPU;

public enum CPUFlag : byte
{
    // Carry bit
    C = 1 << 0,
    // Zero bit
    Z = 1 << 1,
    // Interupts disabled
    I = 1 << 2,
    // Break
    B = 1 << 4,
    // Unused
    U = 1 << 5,
    // Overflow
    V = 1 << 6,
    // Negative
    N = 1 << 7
}