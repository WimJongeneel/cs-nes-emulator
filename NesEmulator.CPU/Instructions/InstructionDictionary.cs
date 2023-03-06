using NesEmulator.CPU.OPCodes;
using NesEmulator.CPU.AddressingModes;

namespace NesEmulator.CPU.Instructions;

public class InstructionDictionary
{

    Dictionary<short, Instruction> Instructions = new()
    {
        { 2,  (new NOP(), new IMP(), 1) },

        { 33, (new AND(), new IZX(), 6) },
        { 37, (new AND(), new ZP0(), 3) },
        { 41, (new AND(), new IMM(), 2) },
        { 45, (new AND(), new ABS(), 4) },
        { 49, (new AND(), new IZY(), 5) },
        { 53, (new AND(), new ZPX(), 4) },
        { 57, (new AND(), new ABY(), 4) },
        { 61, (new AND(), new ABX(), 4) },

        { 230, (new INC(), new ZP0(), 5) },
        { 246, (new INC(), new ZPX(), 6) },
        { 254, (new INC(), new ABX(), 7) },

        { 231, (new INX(), new IMP(), 2) },

        { 200, (new INY(), new IMP(), 2) },

        { 76, (new JMP(), new ABS(), 3) },
        { 108, (new JMP(), new IND(), 5) },

        { 161, (new LDA(), new IZX(), 6) },
        { 165, (new LDA(), new ZP0(), 3) },
        { 165, (new LDA(), new IMM(), 2) },
        { 173, (new LDA(), new ABS(), 4) },
        { 177, (new LDA(), new IZY(), 5) },
        { 181, (new LDA(), new ZPX(), 4) },
        { 185, (new LDA(), new ABY(), 4) },
        { 189, (new LDA(), new ABX(), 4) },
        { 189, (new LDA(), new ABX(), 4) },
    };

    public Instruction LookUp(short op)
    {
        if(Instructions.ContainsKey(op)) return Instructions[op];
        return (new NOP(), new IMP(), 1);
    }
}