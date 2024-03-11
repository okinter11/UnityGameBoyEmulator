namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op3X
    {
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

        public static void X36_LD_HL_N8(Cpu cpu)
        {
            byte data = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            Op.Write(cpu, cpu.Reg.HL, data);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X3A_LD_A_HLd(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.Reg.HL);
            cpu.Reg.HL -= 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X3E_LD_A_N8(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }
    }
}