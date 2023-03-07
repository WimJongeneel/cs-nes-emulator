using NESEmulator.CPU.OPCodes;
using NESEmulator.CPU.AddressingModes;

namespace NESEmulator.CPU.Instructions;

public class InstructionDictionary
{
    Dictionary<short, Instruction> Instructions = new()
    {
        // { 0, (new BRK(), new IMM(), 7) },
        { 1, (new ORA(), new IZX(), 6) },
        { 5, (new ORA(), new ZP0(), 3) },
        // { 6, (new ASL(), new ZP0(), 5) },
        // { 8, (new PHP(), new IMP(), 3) },
        { 9, (new ORA(), new IMM(), 2) },
        // { 10, (new ASL(), new IMP(), 2) },
        { 13, (new ORA(), new ABS(), 4) },
        // { 14, (new ASL(), new ABS(), 6) },
        // { 16, (new BPL(), new REL(), 2) },
        { 17, (new ORA(), new IZY(), 5) },
        { 21, (new ORA(), new ZPX(), 4) },
        // { 22, (new ASL(), new ZPX(), 6) },
        { 24, (new CLC(), new IMP(), 2) },
        { 25, (new ORA(), new ABY(), 4) },
        { 29, (new ORA(), new ABX(), 4) },
        // { 30, (new ASL(), new ABX(), 7) },
        // { 32, (new JSR(), new ABS(), 6) },
        { 33, (new AND(), new IZX(), 6) },
        // { 36, (new BIT(), new ZP0(), 3) },
        { 37, (new AND(), new ZP0(), 3) },
        // { 38, (new ROL(), new ZP0(), 5) },
        // { 40, (new PLP(), new IMP(), 4) },
        { 41, (new AND(), new IMM(), 2) },
        // { 42, (new ROL(), new IMP(), 2) },
        // { 44, (new BIT(), new ABS(), 4) },
        { 45, (new AND(), new ABS(), 4) },
        // { 46, (new ROL(), new ABS(), 6) },
        // { 48, (new BMI(), new REL(), 2) },
        { 49, (new AND(), new IZY(), 5) },
        { 53, (new AND(), new ZPX(), 4) },
        // { 54, (new ROL(), new ZPX(), 6) },
        { 56, (new SEC(), new IMP(), 2) },
        { 57, (new AND(), new ABY(), 4) },
        { 61, (new AND(), new ABX(), 4) },
        // { 62, (new ROL(), new ABX(), 7) },
        // { 64, (new RTI(), new IMP(), 6) },
        { 65, (new EOR(), new IZX(), 6) },
        { 69, (new EOR(), new ZP0(), 3) },
        // { 70, (new LSR(), new ZP0(), 5) },
        // { 72, (new PHA(), new IMP(), 3) },
        { 73, (new EOR(), new IMM(), 2) },
        // { 74, (new LSR(), new IMP(), 2) },
        { 76, (new JMP(), new ABS(), 3) },
        { 77, (new EOR(), new ABS(), 4) },
        // { 78, (new LSR(), new ABS(), 6) },
        // { 80, (new BVC(), new REL(), 2) },
        { 81, (new EOR(), new IZY(), 5) },
        { 85, (new EOR(), new ZPX(), 4) },
        // { 86, (new LSR(), new ZPX(), 6) },
        { 88, (new CLI(), new IMP(), 2) },
        { 89, (new EOR(), new ABY(), 4) },
        { 93, (new EOR(), new ABX(), 4) },
        // { 94, (new LSR(), new ABX(), 7) },
        // { 96, (new RTS(), new IMP(), 6) },
        // { 97, (new ADC(), new IZX(), 6) },
        // { 101, (new ADC(), new ZP0(), 3) },
        // { 102, (new ROR(), new ZP0(), 5) },
        // { 104, (new PLA(), new IMP(), 4) },
        // { 105, (new ADC(), new IMM(), 2) },
        // { 106, (new ROR(), new IMP(), 2) },
        { 108, (new JMP(), new IND(), 5) },
        // { 109, (new ADC(), new ABS(), 4) },
        // { 110, (new ROR(), new ABS(), 6) },
        // { 112, (new BVS(), new REL(), 2) },
        // { 113, (new ADC(), new IZY(), 5) },
        // { 117, (new ADC(), new ZPX(), 4) },
        // { 118, (new ROR(), new ZPX(), 6) },
        { 120, (new SEI(), new IMP(), 2) },
        // { 121, (new ADC(), new ABY(), 4) },
        // { 125, (new ADC(), new ABX(), 4) },
        // { 126, (new ROR(), new ABX(), 7) },
        { 129, (new STA(), new IZX(), 6) },
        { 132, (new STY(), new ZP0(), 3) },
        { 133, (new STA(), new ZP0(), 3) },
        { 134, (new STX(), new ZP0(), 3) },
        { 136, (new DEY(), new IMP(), 2) },
        { 138, (new TXA(), new IMP(), 2) },
        { 140, (new STY(), new ABS(), 4) },
        { 141, (new STA(), new ABS(), 4) },
        { 142, (new STX(), new ABS(), 4) },
        // { 144, (new BCC(), new REL(), 2) },
        { 145, (new STA(), new IZY(), 6) },
        { 148, (new STY(), new ZPX(), 4) },
        { 149, (new STA(), new ZPX(), 4) },
        { 150, (new STX(), new ZPY(), 4) },
        { 152, (new TYA(), new IMP(), 2) },
        { 153, (new STA(), new ABY(), 5) },
        { 154, (new TXS(), new IMP(), 2) },
        { 157, (new STA(), new ABX(), 5) },
        { 160, (new LDY(), new IMM(), 2) },
        { 161, (new LDA(), new IZX(), 6) },
        { 162, (new LDX(), new IMM(), 2) },
        { 164, (new LDY(), new ZP0(), 3) },
        { 165, (new LDA(), new ZP0(), 3) },
        { 166, (new LDX(), new ZP0(), 3) },
        { 168, (new TAY(), new IMP(), 2) },
        { 169, (new LDA(), new IMM(), 2) },
        { 170, (new TAX(), new IMP(), 2) },
        { 172, (new LDY(), new ABS(), 4) },
        { 173, (new LDA(), new ABS(), 4) },
        { 174, (new LDX(), new ABS(), 4) },
        // { 176, (new BCS(), new REL(), 2) },
        { 177, (new LDA(), new IZY(), 5) },
        { 180, (new LDY(), new ZPX(), 4) },
        { 181, (new LDA(), new ZPX(), 4) },
        { 182, (new LDX(), new ZPY(), 4) },
        { 184, (new CLV(), new IMP(), 2) },
        { 185, (new LDA(), new ABY(), 4) },
        { 186, (new TSX(), new IMP(), 2) },
        { 188, (new LDY(), new ABX(), 4) },
        { 189, (new LDA(), new ABX(), 4) },
        { 190, (new LDX(), new ABY(), 4) },
        { 192, (new CPY(), new IMM(), 2) },
        { 193, (new CMP(), new IZX(), 6) },
        { 196, (new CPY(), new ZP0(), 3) },
        { 197, (new CMP(), new ZP0(), 3) },
        { 198, (new DEC(), new ZP0(), 5) },
        { 200, (new INY(), new IMP(), 2) },
        { 201, (new CMP(), new IMM(), 2) },
        { 202, (new DEX(), new IMP(), 2) },
        { 204, (new CPY(), new ABS(), 4) },
        { 205, (new CMP(), new ABS(), 4) },
        { 206, (new DEC(), new ABS(), 6) },
        // { 208, (new BNE(), new REL(), 2) },
        { 209, (new CMP(), new IZY(), 5) },
        { 213, (new CMP(), new ZPX(), 4) },
        { 214, (new DEC(), new ZPX(), 6) },
        { 216, (new CLD(), new IMP(), 2) },
        { 217, (new CMP(), new ABY(), 4) },
        { 221, (new CMP(), new ABX(), 4) },
        { 222, (new DEC(), new ABX(), 7) },
        { 224, (new CPX(), new IMM(), 2) },
        // { 225, (new SBC(), new IZX(), 6) },
        { 228, (new CPX(), new ZP0(), 3) },
        // { 229, (new SBC(), new ZP0(), 3) },
        { 230, (new INC(), new ZP0(), 5) },
        { 232, (new INX(), new IMP(), 2) },
        // { 233, (new SBC(), new IMM(), 2) },
        // { 235, (new SBC(), new IMP(), 2) },
        { 236, (new CPX(), new ABS(), 4) },
        // { 237, (new SBC(), new ABS(), 4) },
        { 238, (new INC(), new ABS(), 6) },
        // { 240, (new BEQ(), new REL(), 2) },
        // { 241, (new SBC(), new IZY(), 5) },
        // { 245, (new SBC(), new ZPX(), 4) },
        { 246, (new INC(), new ZPX(), 6) },
        { 248, (new SED(), new IMP(), 2) },
        // { 249, (new SBC(), new ABY(), 4) },
        // { 253, (new SBC(), new ABX(), 4) },
        { 254, (new INC(), new ABX(), 7) },
    };

    public Instruction LookUp(short op)
    {
        if(Instructions.ContainsKey(op)) return Instructions[op];
        return (new NOP(), new IMP(), 1);
    }
}