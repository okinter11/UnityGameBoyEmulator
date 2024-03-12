namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op7X
    {
        public static void X70_LD_HL_B(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.B);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X71_LD_HL_C(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.C);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X72_LD_HL_D(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.D);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X73_LD_HL_E(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.E);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X74_LD_HL_H(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.H);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X75_LD_HL_L(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.L);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X76_HALT(Cpu cpu)
        {
            cpu.Halted = true;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X77_LD_HL_A(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.A);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X78_LD_A_B(Cpu cpu)
        {
            cpu.Reg.A = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X79_LD_A_C(Cpu cpu)
        {
            cpu.Reg.A = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X7A_LD_A_D(Cpu cpu)
        {
            cpu.Reg.A = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X7B_LD_A_E(Cpu cpu)
        {
            cpu.Reg.A = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X7C_LD_A_H(Cpu cpu)
        {
            cpu.Reg.A = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X7D_LD_A_L(Cpu cpu)
        {
            cpu.Reg.A = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X7E_LD_A_HL(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X7F_LD_A_A(Cpu cpu)
        {
            // cpu.Reg.A = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}