﻿namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpFX
    {
        public static void XF0_LDH_A_A8(Cpu cpu)
        {
            byte address = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            cpu.Reg.A = Op.Read(cpu, Ram.MAP_IO_REGISTERS + address);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void XF2_LDH_A_C(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, Ram.MAP_IO_REGISTERS + cpu.Reg.C);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void XF3_DI(Cpu cpu)
        {
            cpu.IME = true;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XF8_LD_HL_SP_N8(Cpu cpu)
        {
            ushort v1 = cpu.Reg.SP;
            short v2 = (sbyte)Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            ushort r = (ushort)(v1 + v2);
            ushort check = (ushort)(v1 ^ v2 ^ r);
            cpu.Reg.HL = r;
            cpu.Reg.z = false;
            cpu.Reg.n = false;
            cpu.Reg.h = (check & 0x10) != 0;
            cpu.Reg.c = (check & 0x100) != 0;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void XF9_LD_SP_HL(Cpu cpu)
        {
            cpu.Reg.SP = cpu.Reg.HL;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void XFA_LD_A_A16(Cpu cpu)
        {
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
            cpu.Reg.A = Op.Read(cpu, Ram.MAP_IO_REGISTERS + address);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
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