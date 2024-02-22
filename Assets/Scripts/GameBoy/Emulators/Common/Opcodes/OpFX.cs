namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpFX
    {
        public static void XF0_LDH_A_A8(Cpu cpu)
        {
            byte address = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.Reg.A = Op.Read(cpu, Ram.MAP_IO_REGISTERS + address);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 12;
        }

        public static void XF3_DI(Cpu cpu)
        {
            cpu.IME = true;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XFE_CP_A_N8(Cpu cpu)
        {
            byte value = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.Reg.z = cpu.Reg.A - value == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (value & 0x0F) > (cpu.Reg.A & 0x0F);
            cpu.Reg.c = value > cpu.Reg.A;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }
    }
}