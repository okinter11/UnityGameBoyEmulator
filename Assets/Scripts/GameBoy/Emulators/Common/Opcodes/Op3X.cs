namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op3X
    {
        public static void X30_JR_NZ_E8(Cpu cpu)
        {
            cpu.ProgramCounter += (ushort)(!cpu.Reg.c ? unchecked((sbyte)Op.Read(cpu, cpu.ProgramCounter + 1)) : 2);
            cpu.ClockCounter += (ulong)(!cpu.Reg.c ? 12 : 8);
        }

        public static void X31_LD_SP_N16(Cpu cpu)
        {
            cpu.Reg.SP = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 12;
        }

        public static void X32_LD_HLd_A(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.A);
            cpu.Reg.HL -= 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X33_INC_SP(Cpu cpu)
        {
            cpu.Reg.SP += 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X34_INC_HL(Cpu cpu)
        {
            byte data = Op.Read(cpu, cpu.Reg.HL);
            cpu.ClockCounter += 4;
            data += 1;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            cpu.Reg.z = data == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (data & 0x0F) == 0;
            Op.Write(cpu, cpu.Reg.HL, data);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X35_DEC_HL(Cpu cpu)
        {
            byte data = Op.Read(cpu, cpu.Reg.HL);
            cpu.ClockCounter += 4;
            data -= 1;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            cpu.Reg.z = data == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (data & 0x0F) == 0x0F;
            Op.Write(cpu, cpu.Reg.HL, data);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X36_LD_HL_N8(Cpu cpu)
        {
            byte data = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            Op.Write(cpu, cpu.Reg.HL, data);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X37_SCF(Cpu cpu)
        {
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = true;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X38_JR_NZ_E8(Cpu cpu)
        {
            cpu.ProgramCounter += (ushort)(cpu.Reg.c ? unchecked((sbyte)Op.Read(cpu, cpu.ProgramCounter + 1)) : 2);
            cpu.ClockCounter += (ulong)(cpu.Reg.c ? 12 : 8);
        }

        public static void X39_ADD_HL_SP(Cpu cpu)
        {
            ushort v1 = cpu.Reg.HL;
            ushort v2 = cpu.Reg.SP;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.HL += v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X3A_LD_A_HLd(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.Reg.HL);
            cpu.Reg.HL -= 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X3B_DEC_SP(Cpu cpu)
        {
            cpu.Reg.SP -= 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X3C_INC_A(Cpu cpu)
        {
            cpu.Reg.A += 1;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (cpu.Reg.A & 0x0F) == 0;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X3D_DEC_A(Cpu cpu)
        {
            cpu.Reg.A -= 1;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (cpu.Reg.A & 0x0F) == 0x0F;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X3E_LD_A_N8(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X3F_CCF(Cpu cpu)
        {
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = !cpu.Reg.c;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}