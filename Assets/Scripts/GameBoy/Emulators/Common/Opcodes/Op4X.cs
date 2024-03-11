namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op4X
    {
        public static void X40_LD_B_B(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X41_LD_B_C(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X42_LD_B_D(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X43_LD_B_E(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X44_LD_B_H(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X45_LD_B_L(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X46_LD_B_HL(Cpu cpu)
        {
            cpu.Reg.B = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X47_LD_B_A(Cpu cpu)
        {
            cpu.Reg.B = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X48_LD_C_B(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X49_LD_C_C(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X4A_LD_C_D(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X4B_LD_C_E(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X4C_LD_C_H(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X4D_LD_C_L(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X4E_LD_C_HL(Cpu cpu)
        {
            cpu.Reg.C = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X4F_LD_C_A(Cpu cpu)
        {
            cpu.Reg.C = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}