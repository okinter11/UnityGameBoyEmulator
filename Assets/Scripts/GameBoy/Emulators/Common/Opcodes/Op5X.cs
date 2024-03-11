namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op5X
    {
        public static void X50_LD_D_B(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X51_LD_D_C(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X52_LD_D_D(Cpu cpu)
        {
            // cpu.Reg.D = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X53_LD_D_E(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X54_LD_D_H(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X55_LD_D_L(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X56_LD_D_HL(Cpu cpu)
        {
            cpu.Reg.D = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X57_LD_D_A(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X58_LD_E_B(Cpu cpu)
        {
            cpu.Reg.E = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X59_LD_E_C(Cpu cpu)
        {
            cpu.Reg.E = cpu.Reg.C;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X5A_LD_E_D(Cpu cpu)
        {
            cpu.Reg.E = cpu.Reg.D;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X5B_LD_E_E(Cpu cpu)
        {
            // cpu.Reg.E = cpu.Reg.E;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X5C_LD_E_H(Cpu cpu)
        {
            cpu.Reg.E = cpu.Reg.H;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X5D_LD_E_L(Cpu cpu)
        {
            cpu.Reg.E = cpu.Reg.L;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X5E_LD_E_HL(Cpu cpu)
        {
            cpu.Reg.E = Op.Read(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X5F_LD_E_A(Cpu cpu)
        {
            cpu.Reg.E = cpu.Reg.A;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}