using System;

namespace GameBoy.Emulators.Common.Opcodes
{
    public sealed class CpuOp
    {
        #region CB Instruction Set

        public static void XCB_PREFIX(Cpu cpu)
        {
            byte opcode = Read(cpu.RomData, cpu.ProgramCounter + 1);
            byte opBit = (byte)((opcode & 0xF8) >> 5);
            byte opReg = (byte)(opcode & 0x07);
            ref byte opRef = ref cpu.Registers.A;
            GetRegister(cpu, opReg, ref opRef);
            CbOperation(cpu, opBit, ref opRef);
        }
        public static void CbOperation(Cpu cpu, byte opBit, ref byte opVal)
        {
            switch (opBit)
            {
                case 0x00:
                    RLC_B(cpu, ref opVal);
                    return;
                case 0x07:
                    throw new NotImplementedException($" cb op {Convert.ToString(opBit, 2)} not implemented");
                    return;
                default: throw new NotImplementedException($" cb op {Convert.ToString(opBit, 2)} not implemented");
            }
        }

        public static void GetRegister(Cpu cpu, byte opReg, ref byte value)
        {
            switch (opReg)
            {
                case 0x00:
                    value = cpu.Registers.B;
                    return;
                case 0x01:
                    value = cpu.Registers.C;
                    return;
                case 0x02:
                    value = cpu.Registers.D;
                    return;
                case 0x03:
                    value = cpu.Registers.E;
                    return;
                case 0x04:
                    value = cpu.Registers.H;
                    return;
                case 0x05:
                    value = cpu.Registers.L;
                    return;
                case 0x06:
                    value = cpu.RomData[cpu.Registers.HL];
                    return;
                case 0x07:
                    value = cpu.Registers.A;
                    return;
                default: throw new NotImplementedException($"Register code {opReg:X2} not implemented");
            }
        }

        public static void RLC_B(Cpu cpu, ref byte value)
        {
            value = (byte)((value << 1) | (value >> 7));
            cpu.Registers.z = value == 0;
            cpu.Registers.n = false;
            cpu.Registers.h = false;
            cpu.Registers.c = (value & 0x80) != 0;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        #endregion

        public const ushort IO_REGISTER_START = 0xFF00;

        public static void Step(Cpu cpu)
        {
            byte opcode = Read(cpu.RomData, cpu.ProgramCounter);
            try
            {
                Instruction[opcode](cpu);
            }
            catch (NotImplementedException e)
            {
                throw new NotImplementedException($"Opcode {opcode:X2} not implemented -> {e}");
            }
        }

        public static byte Read(byte[] romData, int address)
        {
            return romData[address];
        }

        public static ushort Read16(byte[] romData, int address)
        {
            return (ushort)(romData[address] | romData[address + 1] << 8);
        }

        public static void Write(byte[] romData, int address, byte value)
        {
            romData[address] = value;
        }

        public static void NOT_IMP(Cpu cpu)
        {
            throw new NotImplementedException();
        }

        public static void X00_NOP(Cpu cpu)
        {
            ++cpu.ProgramCounter;
            cpu.ClockCounter += 4;
        }

        public static void XC3_JP_A16(Cpu cpu)
        {
            ushort address = Read16(cpu.RomData, cpu.ProgramCounter + 1);
            cpu.ProgramCounter = address;
            cpu.ClockCounter += 16;
        }

        public static void XC4_CALL_NZ_A16(Cpu cpu)
        {
            if (!cpu.Registers.z)
            {
                cpu.CallStack.Push(cpu.ProgramCounter);
                ushort address = Read16(cpu.RomData, cpu.ProgramCounter + 1);
                cpu.ProgramCounter = address;
                cpu.ClockCounter += 24;
            }
            else
            {
                cpu.ProgramCounter += 3;
                cpu.ClockCounter += 12;
            }
        }

        public static void XCD_CALL_A16(Cpu cpu)
        {
            cpu.CallStack.Push(cpu.ProgramCounter);
            ushort address = Read16(cpu.RomData, cpu.ProgramCounter + 1);
            cpu.ProgramCounter = address;
            cpu.ClockCounter += 24;
        }

        public static void XF0_LDH_A_A8(Cpu cpu)
        {
            byte address = Read(cpu.RomData, cpu.ProgramCounter + 1);
            cpu.Registers.A = Read(cpu.RomData, IO_REGISTER_START + address);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 12;
        }

        public static void XE0_LDH_A8_A(Cpu cpu)
        {
            byte address = Read(cpu.RomData, cpu.ProgramCounter + 1);
            Write(cpu.RomData, IO_REGISTER_START + address, cpu.Registers.A);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 12;
        }

        public static readonly Action<Cpu>[] Instruction = new Action<Cpu>[]
        {
            // 0x00 - 0x0F
            X00_NOP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x10 - 0x1F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x20 - 0x2F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x30 - 0x3F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x40 - 0x4F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x50 - 0x5F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x60 - 0x6F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x70 - 0x7F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x80 - 0x8F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0x90 - 0x9F
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xA0 - 0xAF
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xB0 - 0xBF
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xC0 - 0xCF
            NOT_IMP, NOT_IMP, NOT_IMP, XC3_JP_A16, XC4_CALL_NZ_A16, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, XCB_PREFIX, NOT_IMP, XCD_CALL_A16, NOT_IMP, NOT_IMP,
            // 0xD0 - 0xDF
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xE0 - 0xEF
            XE0_LDH_A8_A, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            // 0xF0 - 0xFF
            XF0_LDH_A_A8, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
            NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP, NOT_IMP,
        };
    }
}