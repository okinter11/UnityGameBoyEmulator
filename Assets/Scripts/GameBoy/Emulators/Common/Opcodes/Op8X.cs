namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op8X
    {
        public static void X80_ADD_A_B(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.B;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X81_ADD_A_C(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.C;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X82_ADD_A_D(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.D;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X83_ADD_A_E(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.E;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X84_ADD_A_H(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.H;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X85_ADD_A_L(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.L;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X86_ADD_A_HL(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = Op.Read(cpu, cpu.Reg.HL);
            cpu.ClockCounter += 4;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X87_ADD_A_A(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.A;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X88_ADC_A_B(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.B;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X89_ADC_A_C(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.C;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X8A_ADC_A_D(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.D;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X8B_ADC_A_E(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.E;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X8C_ADC_A_H(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.H;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X8D_ADC_A_L(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.L;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X8E_ADC_A_HL(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = Op.Read(cpu, cpu.Reg.HL);
            cpu.ClockCounter += 4;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X8F_ADC_A_A(Cpu cpu)
        {
            byte c = cpu.Reg.c ? (byte)1 : (byte)0;
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.A;
            byte r = (byte)(v1 + v2 + c);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2, c);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2, c);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}