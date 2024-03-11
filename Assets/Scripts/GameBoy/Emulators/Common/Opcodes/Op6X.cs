namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op6X
    {
        public static void X60_LD_H_B(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X61_LD_H_C(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X62_LD_H_D(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X63_LD_H_E(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X64_LD_H_H(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X65_LD_H_L(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X66_LD_H_HL(Cpu cpu)
        {
            cpu.Reg.H = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X67_LD_H_A(Cpu cpu)
        {
            cpu.Reg.H = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X68_LD_L_B(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X69_LD_L_C(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X6A_LD_L_D(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X6B_LD_L_E(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X6C_LD_L_H(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X6D_LD_L_L(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X6E_LD_L_HL(Cpu cpu)
        {
            cpu.Reg.L = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X6F_LD_L_A(Cpu cpu)
        {
            cpu.Reg.L = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}