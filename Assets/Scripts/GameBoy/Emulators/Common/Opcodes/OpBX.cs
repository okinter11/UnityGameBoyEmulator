namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpBX
    {
        public static void XB8_CP_A_B(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.B;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
        public static void XB9_CP_A_C(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.C;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
        public static void XBA_CP_A_D(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.D;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
        public static void XBB_CP_A_E(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.E;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
        public static void XBC_CP_A_H(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.H;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
        public static void XBD_CP_A_L(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.L;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
        
        public static void XBE_CP_A_HL(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = Op.Read(cpu, cpu.Reg.HL);
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }
        public static void XBF_CP_A_A(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = cpu.Reg.A;
            sbyte r = (sbyte)((sbyte)v1 - (sbyte)v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (v1 & 0x0F) < (v2 & 0x0F);
            cpu.Reg.c = v1 < v2;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}