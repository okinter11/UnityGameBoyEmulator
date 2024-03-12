namespace GameBoy.Emulators.Common.Opcodes
{
    public class OpCX
    {
        public static void XC0_RET_NZ(Cpu cpu)
        {
            if (!cpu.Reg.z)
            {
                cpu.ProgramCounter = Op.Pop16(cpu);
                cpu.ClockCounter += 20;
            }
            else
            {
                cpu.ProgramCounter += 1;
                cpu.ClockCounter += 8;
            }
        }

        public static void XC1_POP_BC(Cpu cpu)
        {
            cpu.Reg.BC = Op.Pop16(cpu);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 12;
        }

        public static void XC2_JP_NZ_A16(Cpu cpu)
        {
            if (!cpu.Reg.z)
            {
                ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
                cpu.ProgramCounter = address;
                cpu.ClockCounter += 16;
            }
            else
            {
                cpu.ProgramCounter += 3;
                cpu.ClockCounter += 12;
            }
        }

        public static void XC3_JP_A16(Cpu cpu)
        {
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter = address;
            cpu.ClockCounter += 16;
        }

        public static void XC4_CALL_NZ_A16(Cpu cpu)
        {
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 12;
            if (!cpu.Reg.z)
            {
                Op.Push16(cpu, cpu.ProgramCounter);
                cpu.ProgramCounter = address;
                cpu.ClockCounter += 12;
            }
        }

        public static void XC5_PUSH_BC(Cpu cpu)
        {
            Op.Push16(cpu, cpu.Reg.BC);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 16;
        }

        public static void XC6_ADD_A_N8(Cpu cpu)
        {
            byte v1 = cpu.Reg.A;
            byte v2 = Op.Read(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
            byte r = (byte)(v1 + v2);
            cpu.Reg.z = r == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = Op.DetectHalfOverflowAdd(v1, v2);
            cpu.Reg.c = Op.DetectOverflowAdd(v1, v2);
            cpu.Reg.A = r;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }

        public static void XC7_RST_00H(Cpu cpu)
        {
            Op.Push16(cpu, cpu.ProgramCounter);
            cpu.ProgramCounter = 0x00;
            cpu.ClockCounter += 16;
        }

        public static void XC8_RET_Z(Cpu cpu)
        {
            if (cpu.Reg.z)
            {
                cpu.ProgramCounter = Op.Pop16(cpu);
                cpu.ClockCounter += 20;
            }
            else
            {
                cpu.ProgramCounter += 1;
                cpu.ClockCounter += 8;
            }
        }

        public static void XC9_RET(Cpu cpu)
        {
            cpu.ProgramCounter = Op.Pop16(cpu);
            cpu.ClockCounter += 16;
        }

        public static void XCA_JP_Z_A16(Cpu cpu)
        {
            if (cpu.Reg.z)
            {
                ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
                cpu.ProgramCounter = address;
                cpu.ClockCounter += 16;
            }
            else
            {
                cpu.ProgramCounter += 3;
                cpu.ClockCounter += 12;
            }
        }

        public static void XCB_PREFIX(Cpu cpu)
        {
            byte opcode = Op.Read(cpu, cpu.ProgramCounter + 1);
            byte opBit = (byte)((opcode & 0xF8) >> 5);
            byte opReg = (byte)(opcode & 0x07);
            ref byte opRef = ref cpu.Reg.A;
            Op.GetRegister(cpu, opReg, ref opRef);
            Op.CbOperation(cpu, opBit, ref opRef);
        }

        public static void XCC_CALL_Z_A16(Cpu cpu)
        {
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 12;
            if (cpu.Reg.z)
            {
                Op.Push16(cpu, cpu.ProgramCounter);
                cpu.ProgramCounter = address;
                cpu.ClockCounter += 12;
            }
        }

        public static void XCD_CALL_A16(Cpu cpu)
        {
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter += 3;
            cpu.ClockCounter += 8;
            Op.Push16(cpu, cpu.ProgramCounter);
            cpu.ProgramCounter = address;
            cpu.ClockCounter += 16;
        }

        public static void XCF_RST_08H(Cpu cpu)
        {
            Op.Push16(cpu, cpu.ProgramCounter);
            cpu.ProgramCounter = 0x08;
            cpu.ClockCounter += 16;
        }
    }
}