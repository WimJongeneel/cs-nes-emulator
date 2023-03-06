using NesEmulator.CPU.OPCodes;
using NesEmulator.CPU.AddressingModes;

namespace NesEmulator.CPU.Instructions;

public class InstructionDictionary
{

    Dictionary<short, Instruction> Instructions = new()
    {
        { 2,  (new NOP(), new IMP(), 1) }
    };

    public Instruction LookUp(short op)
    {
        if(Instructions.ContainsKey(op)) return Instructions[op];
        return (new NOP(), new IMP(), 1);
    }
}