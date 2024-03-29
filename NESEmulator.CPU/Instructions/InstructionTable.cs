using NESEmulator.CPU.OPCodes;
using NESEmulator.CPU.AddressingModes;

namespace NESEmulator.CPU.Instructions;

public class InstructionTable
{
    Dictionary<ushort, Instruction> Instructions = new()
    {
        { 0, (new BRK_Break(), new IMM_Immediate(), 7) },
        { 1, (new ORA_BitwiseLogicOR(), new IZX_IndirectWithXOffset(), 6) },
        { 5, (new ORA_BitwiseLogicOR(), new ZP0_ZeroPage(), 3) },
        { 6, (new ASL_ArithmeticShiftLeft(), new ZP0_ZeroPage(), 5) },
        { 8, (new PHP_PushStatus(), new IMP_Implied(), 3) },
        { 9, (new ORA_BitwiseLogicOR(), new IMM_Immediate(), 2) },
        { 10, (new ASL_ArithmeticShiftLeft(), new IMP_Implied(), 2) },
        { 13, (new ORA_BitwiseLogicOR(), new ABS_Absolute(), 4) },
        { 14, (new ASL_ArithmeticShiftLeft(), new ABS_Absolute(), 6) },
        { 16, (new BPL_BranchIfPositive(), new REL_Relative(), 2) },
        { 17, (new ORA_BitwiseLogicOR(), new IZY_IndirectWithYOffset(), 5) },
        { 21, (new ORA_BitwiseLogicOR(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 22, (new ASL_ArithmeticShiftLeft(), new ZPX_ZeroPageWithXOffset(), 6) },
        { 24, (new CLC_ClearCarryFlag(), new IMP_Implied(), 2) },
        { 25, (new ORA_BitwiseLogicOR(), new ABY_AbsoluteWithYOffset(), 4) },
        { 29, (new ORA_BitwiseLogicOR(), new ABX_AbsoluteWithXOffset(), 4) },
        { 30, (new ASL_ArithmeticShiftLeft(), new ABX_AbsoluteWithXOffset(), 7) },
        { 32, (new JSR_JumpToSubRoutine(), new ABS_Absolute(), 6) },
        { 33, (new AND_BitwiseLogicAND(), new IZX_IndirectWithXOffset(), 6) },
        { 36, (new BIT_NonDestructiveAND(), new ZP0_ZeroPage(), 3) },
        { 37, (new AND_BitwiseLogicAND(), new ZP0_ZeroPage(), 3) },
        { 38, (new ROL_RotateLeft(), new ZP0_ZeroPage(), 5) },
        { 40, (new PLP_PopStatus(), new IMP_Implied(), 4) },
        { 41, (new AND_BitwiseLogicAND(), new IMM_Immediate(), 2) },
        { 42, (new ROL_RotateLeft(), new IMP_Implied(), 2) },
        { 44, (new BIT_NonDestructiveAND(), new ABS_Absolute(), 4) },
        { 45, (new AND_BitwiseLogicAND(), new ABS_Absolute(), 4) },
        { 46, (new ROL_RotateLeft(), new ABS_Absolute(), 6) },
        { 48, (new BMI_BranchIfNegative(), new REL_Relative(), 2) },
        { 49, (new AND_BitwiseLogicAND(), new IZY_IndirectWithYOffset(), 5) },
        { 53, (new AND_BitwiseLogicAND(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 54, (new ROL_RotateLeft(), new ZPX_ZeroPageWithXOffset(), 6) },
        { 56, (new SEC_SetCarryFlag(), new IMP_Implied(), 2) },
        { 57, (new AND_BitwiseLogicAND(), new ABY_AbsoluteWithYOffset(), 4) },
        { 61, (new AND_BitwiseLogicAND(), new ABX_AbsoluteWithXOffset(), 4) },
        { 62, (new ROL_RotateLeft(), new ABX_AbsoluteWithXOffset(), 7) },
        { 64, (new RTI_ReturnFromInterrupt(), new IMP_Implied(), 6) },
        { 65, (new EOR_BitwiseLogicXOR(), new IZX_IndirectWithXOffset(), 6) },
        { 69, (new EOR_BitwiseLogicXOR(), new ZP0_ZeroPage(), 3) },
        { 70, (new LSR_LogicalShiftRight(), new ZP0_ZeroPage(), 5) },
        { 72, (new PHA_PushA(), new IMP_Implied(), 3) },
        { 73, (new EOR_BitwiseLogicXOR(), new IMM_Immediate(), 2) },
        { 74, (new LSR_LogicalShiftRight(), new IMP_Implied(), 2) },
        { 76, (new JMP_JumpToAddress(), new ABS_Absolute(), 3) },
        { 77, (new EOR_BitwiseLogicXOR(), new ABS_Absolute(), 4) },
        { 78, (new LSR_LogicalShiftRight(), new ABS_Absolute(), 6) },
        { 80, (new BVC_BranchIfOverflowClear(), new REL_Relative(), 2) },
        { 81, (new EOR_BitwiseLogicXOR(), new IZY_IndirectWithYOffset(), 5) },
        { 85, (new EOR_BitwiseLogicXOR(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 86, (new LSR_LogicalShiftRight(), new ZPX_ZeroPageWithXOffset(), 6) },
        { 88, (new CLI_ClearInterruptFlag(), new IMP_Implied(), 2) },
        { 89, (new EOR_BitwiseLogicXOR(), new ABY_AbsoluteWithYOffset(), 4) },
        { 93, (new EOR_BitwiseLogicXOR(), new ABX_AbsoluteWithXOffset(), 4) },
        { 94, (new LSR_LogicalShiftRight(), new ABX_AbsoluteWithXOffset(), 7) },
        { 96, (new RTS_ReturnFromSubroutine(), new IMP_Implied(), 6) },
        { 97, (new ADD_WithCarryIn(), new IZX_IndirectWithXOffset(), 6) },
        { 101, (new ADD_WithCarryIn(), new ZP0_ZeroPage(), 3) },
        { 102, (new ROR_RotateRight(), new ZP0_ZeroPage(), 5) },
        { 104, (new PLA_PopA(), new IMP_Implied(), 4) },
        { 105, (new ADD_WithCarryIn(), new IMM_Immediate(), 2) },
        { 106, (new ROR_RotateRight(), new IMP_Implied(), 2) },
        { 108, (new JMP_JumpToAddress(), new IND_Indirect(), 5) },
        { 109, (new ADD_WithCarryIn(), new ABS_Absolute(), 4) },
        { 110, (new ROR_RotateRight(), new ABS_Absolute(), 6) },
        { 112, (new BVS_BranchIfOverflowSet(), new REL_Relative(), 2) },
        { 113, (new ADD_WithCarryIn(), new IZY_IndirectWithYOffset(), 5) },
        { 117, (new ADD_WithCarryIn(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 118, (new ROR_RotateRight(), new ZPX_ZeroPageWithXOffset(), 6) },
        { 120, (new SEI_SetInterruptFlag(), new IMP_Implied(), 2) },
        { 121, (new ADD_WithCarryIn(), new ABY_AbsoluteWithYOffset(), 4) },
        { 125, (new ADD_WithCarryIn(), new ABX_AbsoluteWithXOffset(), 4) },
        { 126, (new ROR_RotateRight(), new ABX_AbsoluteWithXOffset(), 7) },
        { 129, (new STA_StoreA(), new IZX_IndirectWithXOffset(), 6) },
        { 132, (new STY_StoreY(), new ZP0_ZeroPage(), 3) },
        { 133, (new STA_StoreA(), new ZP0_ZeroPage(), 3) },
        { 134, (new STX_StoreX(), new ZP0_ZeroPage(), 3) },
        { 136, (new DEY_DecrementY(), new IMP_Implied(), 2) },
        { 138, (new TSA_TransferStackPointerToA(), new IMP_Implied(), 2) },
        { 140, (new STY_StoreY(), new ABS_Absolute(), 4) },
        { 141, (new STA_StoreA(), new ABS_Absolute(), 4) },
        { 142, (new STX_StoreX(), new ABS_Absolute(), 4) },
        { 144, (new BCC_BranchIfCarryClear(), new REL_Relative(), 2) },
        { 145, (new STA_StoreA(), new IZY_IndirectWithYOffset(), 6) },
        { 148, (new STY_StoreY(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 149, (new STA_StoreA(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 150, (new STX_StoreX(), new ZPY_ZeroPageWithYOffset(), 4) },
        { 152, (new TYA_TransferYToA(), new IMP_Implied(), 2) },
        { 153, (new STA_StoreA(), new ABY_AbsoluteWithYOffset(), 5) },
        { 154, (new TXS_TransferXToStackPointer(), new IMP_Implied(), 2) },
        { 157, (new STA_StoreA(), new ABX_AbsoluteWithXOffset(), 5) },
        { 160, (new LDY_LoadY(), new IMM_Immediate(), 2) },
        { 161, (new LDA_LoadA(), new IZX_IndirectWithXOffset(), 6) },
        { 162, (new LDX_LoadX(), new IMM_Immediate(), 2) },
        { 164, (new LDY_LoadY(), new ZP0_ZeroPage(), 3) },
        { 165, (new LDA_LoadA(), new ZP0_ZeroPage(), 3) },
        { 166, (new LDX_LoadX(), new ZP0_ZeroPage(), 3) },
        { 168, (new TAY_TransferAToY(), new IMP_Implied(), 2) },
        { 169, (new LDA_LoadA(), new IMM_Immediate(), 2) },
        { 170, (new TAX_TransferAToX(), new IMP_Implied(), 2) },
        { 172, (new LDY_LoadY(), new ABS_Absolute(), 4) },
        { 173, (new LDA_LoadA(), new ABS_Absolute(), 4) },
        { 174, (new LDX_LoadX(), new ABS_Absolute(), 4) },
        { 176, (new BCS_BranchIfCarrySet(), new REL_Relative(), 2) },
        { 177, (new LDA_LoadA(), new IZY_IndirectWithYOffset(), 5) },
        { 180, (new LDY_LoadY(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 181, (new LDA_LoadA(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 182, (new LDX_LoadX(), new ZPY_ZeroPageWithYOffset(), 4) },
        { 184, (new CLV_ClearOverflowFlag(), new IMP_Implied(), 2) },
        { 185, (new LDA_LoadA(), new ABY_AbsoluteWithYOffset(), 4) },
        { 186, (new TSX_TransferStackPointerToX(), new IMP_Implied(), 2) },
        { 188, (new LDY_LoadY(), new ABX_AbsoluteWithXOffset(), 4) },
        { 189, (new LDA_LoadA(), new ABX_AbsoluteWithXOffset(), 4) },
        { 190, (new LDX_LoadX(), new ABY_AbsoluteWithYOffset(), 4) },
        { 192, (new CPY_CompareY(), new IMM_Immediate(), 2) },
        { 193, (new CMP_CompareA(), new IZX_IndirectWithXOffset(), 6) },
        { 196, (new CPY_CompareY(), new ZP0_ZeroPage(), 3) },
        { 197, (new CMP_CompareA(), new ZP0_ZeroPage(), 3) },
        { 198, (new DEC_DecrementAtMemoryAddress(), new ZP0_ZeroPage(), 5) },
        { 200, (new INY_IncrementY(), new IMP_Implied(), 2) },
        { 201, (new CMP_CompareA(), new IMM_Immediate(), 2) },
        { 202, (new DEX_DecrementX(), new IMP_Implied(), 2) },
        { 204, (new CPY_CompareY(), new ABS_Absolute(), 4) },
        { 205, (new CMP_CompareA(), new ABS_Absolute(), 4) },
        { 206, (new DEC_DecrementAtMemoryAddress(), new ABS_Absolute(), 6) },
        { 208, (new BNE_BranchIfNotEqual(), new REL_Relative(), 2) },
        { 209, (new CMP_CompareA(), new IZY_IndirectWithYOffset(), 5) },
        { 213, (new CMP_CompareA(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 214, (new DEC_DecrementAtMemoryAddress(), new ZPX_ZeroPageWithXOffset(), 6) },
        { 216, (new CLD_ClearDecimalFlag(), new IMP_Implied(), 2) },
        { 217, (new CMP_CompareA(), new ABY_AbsoluteWithYOffset(), 4) },
        { 221, (new CMP_CompareA(), new ABX_AbsoluteWithXOffset(), 4) },
        { 222, (new DEC_DecrementAtMemoryAddress(), new ABX_AbsoluteWithXOffset(), 7) },
        { 224, (new CPX_CompareX(), new IMM_Immediate(), 2) },
        { 225, (new SBC_SubtractionWithBorrowIn(), new IZX_IndirectWithXOffset(), 6) },
        { 228, (new CPX_CompareX(), new ZP0_ZeroPage(), 3) },
        { 229, (new SBC_SubtractionWithBorrowIn(), new ZP0_ZeroPage(), 3) },
        { 230, (new INC_IncrementAtMemoryAddress(), new ZP0_ZeroPage(), 5) },
        { 232, (new INX_IncrementX(), new IMP_Implied(), 2) },
        { 233, (new SBC_SubtractionWithBorrowIn(), new IMM_Immediate(), 2) },
        { 235, (new SBC_SubtractionWithBorrowIn(), new IMP_Implied(), 2) },
        { 236, (new CPX_CompareX(), new ABS_Absolute(), 4) },
        { 237, (new SBC_SubtractionWithBorrowIn(), new ABS_Absolute(), 4) },
        { 238, (new INC_IncrementAtMemoryAddress(), new ABS_Absolute(), 6) },
        { 240, (new BEQ_BranchIfEqual(), new REL_Relative(), 2) },
        { 241, (new SBC_SubtractionWithBorrowIn(), new IZY_IndirectWithYOffset(), 5) },
        { 245, (new SBC_SubtractionWithBorrowIn(), new ZPX_ZeroPageWithXOffset(), 4) },
        { 246, (new INC_IncrementAtMemoryAddress(), new ZPX_ZeroPageWithXOffset(), 6) },
        { 248, (new SED_SetDecimalFlag(), new IMP_Implied(), 2) },
        { 249, (new SBC_SubtractionWithBorrowIn(), new ABY_AbsoluteWithYOffset(), 4) },
        { 253, (new SBC_SubtractionWithBorrowIn(), new ABX_AbsoluteWithXOffset(), 4) },
        { 254, (new INC_IncrementAtMemoryAddress(), new ABX_AbsoluteWithXOffset(), 7) },
    };

    public Instruction LookUp(ushort op)
    {
        if(Instructions.ContainsKey(op)) return Instructions[op];
        return (new NOP_NoOp(), new IMP_Implied(), 1);
    }
}