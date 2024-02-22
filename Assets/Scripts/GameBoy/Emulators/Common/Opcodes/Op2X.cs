namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op2X
    {
        public static void X20_JR_NZ_E8(Cpu cpu)
        {
            cpu.ProgramCounter += (ushort)(!cpu.Reg.z ? unchecked((sbyte)Op.Read(cpu, cpu.ProgramCounter + 1)) : 2);
            cpu.ClockCounter += (ulong)(!cpu.Reg.z ? 12 : 8);
        }

        public static void X21_LD_HL_N16(Cpu cpu)
        {
            cpu.Reg.HL = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 12;
        }

        public static void X22_LD_HLi_A(Cpu cpu)
        {
            Op.Write(cpu, cpu.Reg.HL, cpu.Reg.A);
            cpu.Reg.HL += 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X23_INC_HL(Cpu cpu)
        {
            cpu.Reg.HL += 1;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 8;
        }

        public static void X24_INC_H(Cpu cpu)
        {
            cpu.Reg.H += 1;
            cpu.Reg.z = cpu.Reg.H == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = (cpu.Reg.H & 0x0F) == 0;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X25_DEC_H(Cpu cpu)
        {
            cpu.Reg.H -= 1;
            cpu.Reg.z = cpu.Reg.H == 0;
            cpu.Reg.n = true;
            cpu.Reg.h = (cpu.Reg.H & 0x0F) == 0x0F;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void X26_LD_H_N8(Cpu cpu)
        {
            cpu.Reg.H = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void X27_DAA(Cpu cpu)
        {
            if (!cpu.Reg.n)
            {
                if (cpu.Reg.h || (cpu.Reg.A & 0x0F) > 9)
                {
                    cpu.Reg.A += 0x06;
                }

                if (cpu.Reg.c || cpu.Reg.A > 0x9F)
                {
                    cpu.Reg.A += 0x60;
                    cpu.Reg.c = true;
                }
            }
            else
            {
                if (cpu.Reg.h)
                {
                    cpu.Reg.A = (byte)(cpu.Reg.A - 0x06);
                }

                if (cpu.Reg.c)
                {
                    cpu.Reg.A = (byte)(cpu.Reg.A - 0x60);
                }
            }

            cpu.Reg.z = cpu.Reg.A == 0;
            cpu.Reg.h = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        // public static void X18_JR_Z_E8(Cpu cpu)
        // {
        //     sbyte sign = unchecked((sbyte)Op.Read(cpu, cpu.ProgramCounter + 1));
        //     cpu.ProgramCounter =  cpu.Reg.z ? (ushort)(cpu.ProgramCounter + sign) : (ushort)(cpu.ProgramCounter + 2);
        //     cpu.ClockCounter += 12;
        // }
        //
        // public static void X19_ADD_HL_DE(Cpu cpu)
        // {
        //     cpu.Reg.n = false;
        //     cpu.Reg.h = Op.DetectHalfOverflowAdd(cpu.Reg.HL, cpu.Reg.DE);
        //     cpu.Reg.c = Op.DetectHalfOverflowAdd(cpu.Reg.HL, cpu.Reg.DE);
        //     cpu.Reg.HL += cpu.Reg.DE;
        //     cpu.ProgramCounter += 1;
        //     cpu.ClockCounter += 8;
        // }
        //
        // public static void X1A_LD_A_DE(Cpu cpu)
        // {
        //     cpu.Reg.A = Op.Read(cpu, cpu.Reg.DE);
        //     cpu.ProgramCounter += 1;
        //     cpu.ClockCounter += 8;
        // }
        //
        // public static void X1B_DEC_DE(Cpu cpu)
        // {
        //     cpu.Reg.DE -= 1;
        //     cpu.ProgramCounter += 1;
        //     cpu.ClockCounter += 8;
        // }
        //
        // public static void X1C_INC_E(Cpu cpu)
        // {
        //     cpu.Reg.E += 1;
        //     cpu.Reg.z = cpu.Reg.E == 0;
        //     cpu.Reg.n = false;
        //     cpu.Reg.h = (cpu.Reg.E & 0x0F) == 0;
        //     cpu.ProgramCounter += 1;
        //     cpu.ClockCounter += 4;
        // }
        //
        // public static void X1D_DEC_E(Cpu cpu)
        // {
        //     cpu.Reg.E -= 1;
        //     cpu.Reg.z = cpu.Reg.E == 0;
        //     cpu.Reg.n = true;
        //     cpu.Reg.h = (cpu.Reg.E & 0x0F) == 0x0F;
        //     cpu.ProgramCounter += 1;
        //     cpu.ClockCounter += 4;
        // }
        //
        // public static void X1E_LD_E_N8(Cpu cpu)
        // {
        //     cpu.Reg.E = Op.Read(cpu, cpu.ProgramCounter + 1);
        //     cpu.ProgramCounter += 2;
        //     cpu.ClockCounter += 8;
        // }
        //
        // public static void X1F_RRA(Cpu cpu)
        // {
        //     int cMask = cpu.Reg.c ? 0x80 : 0x00;
        //     cpu.Reg.z = false;
        //     cpu.Reg.n = false;
        //     cpu.Reg.h = false;
        //     cpu.Reg.c = (cpu.Reg.A & 0x01) == 1;
        //     cpu.Reg.A = (byte)((cpu.Reg.A >> 1) | cMask);
        //     cpu.ProgramCounter += 1;
        //     cpu.ClockCounter += 4;
        // }
    }
}