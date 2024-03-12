using System;

namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op
    {
        #region OverFlowDetect

        public static bool DetectHalfOverflowAdd(byte left, byte right, byte val = 0)
            => (left & 0x0F)
             + (right & 0x0F)
             + val
             > 0x0F;

        public static bool DetectOverflowAdd(byte left, byte right, byte val = 0)
            => left
             + right
             + val
             > 0xFF;

        public static bool DetectHalfOverflowAdd(ushort left, ushort right, ushort val = 0)
            => (left & 0x00FF)
             + (right & 0x00FF)
             + val
             > 0x00FF;

        public static bool DetectOverflowAdd(ushort left, ushort right, ushort val = 0)
            => left
             + right
             + val
             > 0xFFFF;

        #endregion

        #region ReadWrite

        public static byte Read(Cpu cpu, int address) => cpu.Ram[address];

        public static ushort Read16(Cpu cpu, int address) => (ushort)(cpu.Ram[address]
                                                                    | (cpu.Ram[address + 1] << 8));

        public static void Write(Cpu cpu, int address, byte value)
        {
            cpu.Ram[address] = value;
        }

        public static void Write16(Cpu cpu, int address, ushort value)
        {
            cpu.Ram[address] = (byte)(value & 0x00FF);
            cpu.Ram[address + 1] = (byte)((value & 0xFF00) >> 8);
        }

        public static void Push16(Cpu cpu, ushort value)
        {
            cpu.Reg.SP -= 2;
            Write16(cpu, cpu.Reg.SP, value);
        }

        public static ushort Pop16(Cpu cpu)
        {
            ushort value = Read16(cpu, cpu.Reg.SP);
            cpu.Reg.SP += 2;
            return value;
        }

        #endregion

        #region CB Instruction Set

        public static void CbOperation(Cpu cpu, byte opBit, ref byte opVal)
        {
            switch (opBit)
            {
                case 0x00: // 00000
                    RLC(cpu, ref opVal);
                    return;
                case 0x01: // 00001
                    RRC(cpu, ref opVal);
                    return;
                case 0x02: // 00010
                    RL(cpu, ref opVal);
                    return;
                case 0x03: // 00011
                    RR(cpu, ref opVal);
                    return;
                case 0x04: // 00100
                    SLA(cpu, ref opVal);
                    return;
                case 0x05: // 00101
                    SRA(cpu, ref opVal);
                    return;
                case 0x06: // 00110
                    SWAP(cpu, ref opVal);
                    return;
                case 0x07: // 00111
                    SRL(cpu, ref opVal);
                    return;
                default:
                    if (opBit <= 0x0F)
                    {
                        BIT(cpu, opVal, (byte)(opBit - 0x08));
                        return;
                    }
                    else if (opBit <= 0x17)
                    {
                        RES(cpu, ref opVal, (byte)(opBit - 0x10));
                        return;
                    }
                    else if (opBit <= 0x1F)
                    {
                        SET(cpu, ref opVal, (byte)(opBit - 0x18));
                        return;
                    }
                    else
                    {
                        throw new Exception($" cb op {Convert.ToString(opBit, 2)} not implemented");
                    }
            }
        }

        public static void GetRegister(Cpu cpu, byte opReg, ref byte value)
        {
            switch (opReg)
            {
                case 0x00:
                    value = ref cpu.Reg.B;
                    return;
                case 0x01:
                    value = ref cpu.Reg.C;
                    return;
                case 0x02:
                    value = ref cpu.Reg.D;
                    return;
                case 0x03:
                    value = ref cpu.Reg.E;
                    return;
                case 0x04:
                    value = ref cpu.Reg.H;
                    return;
                case 0x05:
                    value = ref cpu.Reg.L;
                    return;
                case 0x06:
                    value = ref cpu.RomData[cpu.Reg.HL];
                    cpu.ClockCounter += 4;
                    return;
                case 0x07:
                    value = ref cpu.Reg.A;
                    return;
                default: throw new Exception($"Register code {opReg:X2} not implemented");
            }
        }

        public static void RLC(Cpu cpu, ref byte value)
        {
            value = (byte)((value << 1) | (value >> 7));
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = (value & 0x01) != 0;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void RRC(Cpu cpu, ref byte value)
        {
            value = (byte)((value >> 1) | (value << 7));
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = (value & 0x80) != 0;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void RL(Cpu cpu, ref byte value)
        {
            byte c = (byte)(value >> 7);
            value = (byte)((value << 1) | (cpu.Reg.c ? 1 : 0));
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = c != 0;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void RR(Cpu cpu, ref byte value)
        {
            byte c = (byte)(value & 0x01);
            value = (byte)((value >> 1) | (cpu.Reg.c ? 0x80 : 0));
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = c != 0;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void SLA(Cpu cpu, ref byte value)
        {
            cpu.Reg.c = (value & 0x80) != 0;
            value = (byte)(value << 1);
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void SRA(Cpu cpu, ref byte value)
        {
            cpu.Reg.c = (value & 0x01) != 0;
            value = (byte)((value & 0x80) | (value >> 1));
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void SRL(Cpu cpu, ref byte value)
        {
            cpu.Reg.c = (value & 0x01) != 0;
            value = (byte)(value >> 1);
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void SWAP(Cpu cpu, ref byte value)
        {
            value = (byte)((value << 4) | (value >> 4));
            cpu.Reg.z = value == 0;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void BIT(Cpu cpu, byte value, byte bit)
        {
            cpu.Reg.z = (value & (1 << bit)) != 0;
            cpu.Reg.n = false;
            cpu.Reg.h = true;
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void RES(Cpu cpu, ref byte value, byte bit)
        {
            value &= (byte)~(1 << bit);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        public static void SET(Cpu cpu, ref byte value, byte bit)
        {
            value |= (byte)(1 << bit);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }

        #endregion
    }
}