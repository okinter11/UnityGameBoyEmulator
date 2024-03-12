namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op0X
    {
        public static void X00_NOP(Cpu cpu)
        {
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X01_LD_BC_N16(Cpu cpu)
        {
            cpu.Reg.BC = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 12;
        }

        public static void X02_LD_BC_A(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.BC, cpu.Reg.A);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X03_INC_BC(Cpu cpu)
        {
            cpu.Reg.BC += 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X04_INC_B(Cpu cpu)
        {
            cpu.Reg.B += 1;
            cpu.Reg.z = cpu.Reg.B == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (cpu.Reg.B & 0x0F) == 0;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X05_DEC_B(Cpu cpu)
        {
            cpu.Reg.B -= 1;
            cpu.Reg.z = cpu.Reg.B == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (cpu.Reg.B & 0x0F) == 0x0F;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X06_LD_B_N8(Cpu cpu)
        {
            cpu.Reg.B = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X07_RLCA(Cpu cpu)
        {
            cpu.Reg.A = (byte)((cpu.Reg.A << 1) | (cpu.Reg.A >> 7));
            cpu.Reg.z = false;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = (cpu.Reg.A & 0x01) == 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X08_LD_A16_SP(Cpu cpu)
        {
            ushort addr = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
            Op.Write(cpu, addr, (byte)(cpu.Reg.SP & 0x00FF));
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            Op.Write(cpu, addr + 1, (byte)((cpu.Reg.SP & 0xFF00) >> 8));
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X09_ADD_HL_BC(Cpu cpu)
        {
            ushort v1 = cpu.Reg.HL;
            ushort v2 = cpu.Reg.BC;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.HL += v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X0A_LD_A_BC(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.Reg.BC);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X0B_DEC_BC(Cpu cpu)
        {
            cpu.Reg.BC -= 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X0C_INC_C(Cpu cpu)
        {
            cpu.Reg.C += 1;
            cpu.Reg.z = cpu.Reg.C == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (cpu.Reg.C & 0x0F) == 0;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X0D_DEC_C(Cpu cpu)
        {
            cpu.Reg.C -= 1;
            cpu.Reg.z = cpu.Reg.C == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (cpu.Reg.C & 0x0F) == 0x0F;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X0E_LD_C_N8(Cpu cpu)
        {
            cpu.Reg.C = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X0F_RRCA(Cpu cpu)
        {
            cpu.Reg.A = (byte)((cpu.Reg.A >> 1) | (cpu.Reg.A << 7));
            cpu.Reg.z = false;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = (cpu.Reg.A & 0x80) == 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}