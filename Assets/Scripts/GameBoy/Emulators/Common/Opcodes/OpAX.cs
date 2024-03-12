namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpAX
    {
        public static void XA0_AND_A_B(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.B;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA1_AND_A_C(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.C;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA2_AND_A_D(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.D;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA3_AND_A_E(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.E;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA4_AND_A_H(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.H;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA5_AND_A_L(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.L;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA6_AND_A_HL(Cpu cpu)
        {
            cpu.Reg.A &= Op.Read(cpu, cpu.Reg.HL);
            cpu.ClockCounter += 4;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA7_AND_A_A(Cpu cpu)
        {
            cpu.Reg.A &= cpu.Reg.A;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA8_XOR_A_B(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.B;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XA9_XOR_A_C(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.C;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XAA_XOR_A_D(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.D;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XAB_XOR_A_E(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.E;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XAC_XOR_A_H(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.H;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XAD_XOR_A_L(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.L;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XAE_XOR_A_HL(Cpu cpu)
        {
            cpu.Reg.A ^= Op.Read(cpu, cpu.Reg.HL);
            cpu.ClockCounter += 4;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XAF_XOR_A_A(Cpu cpu)
        {
            cpu.Reg.A ^= cpu.Reg.B;
            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}