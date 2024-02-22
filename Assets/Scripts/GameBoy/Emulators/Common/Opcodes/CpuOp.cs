using System;

namespace GameBoy.Emulators.Common.Opcodes
{
    // https://rgbds.gbdev.io/docs/v0.7.0/gbz80.7
    // https://gbdev.io/gb-opcodes/optables/
    public sealed class CpuOp
    {
        public static readonly Action<Cpu>[] Instruction = new Action<Cpu>[]
        {
            // 0x00 - 0x0F
            Op0X.X00_NOP, Op0X.X01_LD_BC_N16, Op0X.X02_LD_BC_A, Op0X.X03_INC_BC,
            Op0X.X04_INC_B, Op0X.X05_DEC_B, Op0X.X06_LD_B_N8, Op0X.X07_RLCA,
            Op0X.X08_LD_A16_SP, Op0X.X09_ADD_HL_BC, Op0X.X0A_LD_A_BC, Op0X.X0B_DEC_BC,
            Op0X.X0C_INC_C, Op0X.X0D_DEC_C, Op0X.X0E_LD_C_N8, Op0X.X0F_RRCA,
            // 0x10 - 0x1F
            Op1X.X10_STOP_N8, Op1X.X11_LD_DE_N16, Op1X.X12_LD_DE_A, Op1X.X13_INC_DE,
            Op1X.X14_INC_D, Op1X.X15_DEC_D, Op1X.X16_LD_D_N8, Op1X.X17_RLA,
            Op1X.X18_JR_E8, Op1X.X19_ADD_HL_DE, Op1X.X1A_LD_A_DE, Op1X.X1B_DEC_DE,
            Op1X.X1C_INC_E, Op1X.X1D_DEC_E, Op1X.X1E_LD_E_N8, Op1X.X1F_RRA,
            // 0x20 - 0x2F
            Op2X.X20_JR_NZ_E8, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x30 - 0x3F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, Op3X.X3E_LD_A_N8, NOT_IMP,
            // 0x40 - 0x4F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x50 - 0x5F
            Op5X.X50_LD_D_B, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x60 - 0x6F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x70 - 0x7F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x80 - 0x8F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x90 - 0x9F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xA0 - 0xAF
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, OpAX.XAF_XOR_A_A,
            // 0xB0 - 0xBF
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xC0 - 0xCF
            NOT_IMP, NOT_IMP, NOT_IMP, OpCX.XC3_JP_A16,
            OpCX.XC4_CALL_NZ_A16, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, OpCX.XCB_PREFIX,
            NOT_IMP, OpCX.XCD_CALL_A16, NOT_IMP, NOT_IMP,
            // 0xD0 - 0xDF
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xE0 - 0xEF
            OpEX.XE0_LDH_A8_A, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xF0 - 0xFF
            OpFX.XF0_LDH_A_A8, NOT_IMP, NOT_IMP, OpFX.XF3_DI,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, OpFX.XFE_CP_A_N8, NOT_IMP,
        };

        public static void NOT_IMP(Cpu cpu)
        {
            throw new Exception("NotImplemented");
        }


        #region Step Increments

        public static void Step(Cpu cpu)
        {
            byte opcode = Op.Read(cpu, cpu.ProgramCounter);
            try
            {
                Instruction[opcode](cpu);
            }
            catch (Exception e)
            {
                throw new Exception($"Opcode {opcode:X2} -> {e}");
            }
        }

        public static void Step(Cpu cpu, double deltaTime)
        {
            int cycles = (int)(Cpu.CLOCK_SPEED * deltaTime);
            for (int i = 0; i < cycles; i++)
            {
                Step(cpu);
            }
        }

        #endregion
    }
}