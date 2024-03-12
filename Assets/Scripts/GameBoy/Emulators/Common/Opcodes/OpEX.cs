namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpEX
    {
        public static void XE0_LDH_A8_A(Cpu cpu)
        {
            byte address = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            Op.Write(cpu, Ram.MAP_IO_REGISTERS + address, cpu.Reg.A);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void XE1_POP_HL(Cpu cpu)
        {
            cpu.Reg.HL = Op.Pop16(cpu);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 12;
        }

        public static void XE2_LDH_C_A(Cpu cpu)
        {
            Op.Write(cpu, Ram.MAP_IO_REGISTERS + cpu.Reg.C, cpu.Reg.A);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void XE5_PUSH_HL(Cpu cpu)
        {
            Op.Push16(cpu, cpu.Reg.HL);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 16;
        }

        public static void XE7_RST_20H(Cpu cpu)
        {
            Op.Push16(cpu, cpu.ProgramCounter);
            cpu.ProgramCounter = 0x20;
            cpu.ClockCounter += 16;
        }

        public static void XE8_ADD_SP_E8(Cpu cpu)
        {
            cpu.Reg.z = false;
            cpu.Reg.n = false;
            ushort v1 = cpu.Reg.SP;
            ushort v2 = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ClockCounter += 4;
            ushort r = (ushort)(v1 + v2);
            ushort check = (ushort)(v1 ^ v2 ^ r);
            cpu.Reg.h = (check & 0x10) != 0;
            cpu.Reg.c = (check & 0x100) != 0;
            cpu.Reg.SP = r;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 12;
        }

        public static void XE9_JP_HL(Cpu cpu)
        {
            cpu.ProgramCounter = cpu.Reg.HL;
            cpu.ClockCounter += 4;
        }

        public static void XEA_LD_A16_A(Cpu cpu)
        {
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
            Op.Write(cpu, Ram.MAP_IO_REGISTERS + address, cpu.Reg.A);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void XEF_RST_28H(Cpu cpu)
        {
            Op.Push16(cpu, cpu.ProgramCounter);
            cpu.ProgramCounter = 0x28;
            cpu.ClockCounter += 16;
        }
    }
}