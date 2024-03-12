namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op9X
    {
        public static void X90_SUB_A_B(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.B;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X91_SUB_A_C(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.C;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X92_SUB_A_D(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.D;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X93_SUB_A_E(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.E;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X94_SUB_A_H(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.H;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X95_SUB_A_L(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.L;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X96_SUB_A_HL(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = Op.Read(cpu, cpu.Reg.HL);
            byte r = (byte)(v1 - v2);
            cpu.ClockCounter += 4;
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X97_SUB_A_A(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.A;
            byte r = (byte)(v1 - v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X98_SUC_A_B(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.B;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X99_SUC_A_C(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.C;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X9A_SUC_A_D(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.D;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X9B_SUC_A_E(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.E;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X9C_SUC_A_H(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.H;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X9D_SUC_A_L(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.L;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X9E_SUC_A_HL(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = Op.Read(cpu, cpu.Reg.HL);
            byte r = (byte)(v1 - v2 - c);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X9F_SUC_A_A(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.A;
            byte r = (byte)(v1 - v2 - c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F) + c;
            cpu.Reg.c = v1 < v2 + c;
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}