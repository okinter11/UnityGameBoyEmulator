using System;

namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op1X
    {
        public static void X10_STOP_N8(Cpu cpu)
        {
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 4;
            throw new NotImplementedException();
        }

        public static void X11_LD_DE_N16(Cpu cpu)
        {
            cpu.Reg.DE = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 12;
        }

        public static void X12_LD_DE_A(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.DE, cpu.Reg.A);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X13_INC_DE(Cpu cpu)
        {
            cpu.Reg.DE += 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X14_INC_D(Cpu cpu)
        {
            cpu.Reg.D += 1;
            cpu.Reg.z = cpu.Reg.D == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (cpu.Reg.D & 0x0F) == 0;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X15_DEC_D(Cpu cpu)
        {
            cpu.Reg.D -= 1;
            cpu.Reg.z = cpu.Reg.D == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (cpu.Reg.D & 0x0F) == 0x0F;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X16_LD_D_N8(Cpu cpu)
        {
            cpu.Reg.D = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X17_RLA(Cpu cpu)
        {
            int cMask = cpu.Reg.c ? 0x01 : 0x00;
            cpu.Reg.z = false;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = (cpu.Reg.A & 0x80) == 1;
            cpu.Reg.A = (byte)((cpu.Reg.A << 1) | cMask);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X18_JR_E8(Cpu cpu)
        {
            sbyte sign = unchecked((sbyte)Op.Read(cpu, cpu.ProgramCounter + 1));
            cpu.ProgramCounter = (ushort)(cpu.ProgramCounter + sign);
            cpu.ClockCounter += 12;
        }

        public static void X19_ADD_HL_DE(Cpu cpu)
        {
            ushort v1 = cpu.Reg.HL;
            ushort v2 = cpu.Reg.DE;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.HL += v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X1A_LD_A_DE(Cpu cpu)
        {
            cpu.Reg.A = Op.Read(cpu, cpu.Reg.DE);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X1B_DEC_DE(Cpu cpu)
        {
            cpu.Reg.DE -= 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X1C_INC_E(Cpu cpu)
        {
            cpu.Reg.E += 1;
            cpu.Reg.z = cpu.Reg.E == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (cpu.Reg.E & 0x0F) == 0;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X1D_DEC_E(Cpu cpu)
        {
            cpu.Reg.E -= 1;
            cpu.Reg.z = cpu.Reg.E == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (cpu.Reg.E & 0x0F) == 0x0F;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X1E_LD_E_N8(Cpu cpu)
        {
            cpu.Reg.E = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X1F_RRA(Cpu cpu)
        {
            int cMask = cpu.Reg.c ? 0x80 : 0x00;
            cpu.Reg.z = false;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = (cpu.Reg.A & 0x01) == 1;
            cpu.Reg.A = (byte)((cpu.Reg.A >> 1) | cMask);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}