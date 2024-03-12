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
                case 0x04: // 00100
                    SLA(cpu, ref opVal);
                    return;
                default: throw new Exception($" cb op {Convert.ToString(opBit, 2)} not implemented");
            }
        }

        public static void GetRegister(Cpu cpu, byte opReg, ref byte value)
        {
            switch (opReg)
            {
                case 0x00:
                    value = cpu.Reg.B;
                    return;
                case 0x01:
                    value = cpu.Reg.C;
                    return;
                case 0x02:
                    value = cpu.Reg.D;
                    return;
                case 0x03:
                    value = cpu.Reg.E;
                    return;
                case 0x04:
                    value = cpu.Reg.H;
                    return;
                case 0x05:
                    value = cpu.Reg.L;
                    return;
                case 0x06:
                    value = cpu.RomData[cpu.Reg.HL];
                    return;
                case 0x07:
                    value = cpu.Reg.A;
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

        #endregion
    }
}