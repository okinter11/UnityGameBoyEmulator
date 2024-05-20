using System;
using GameBoy.Emulators.Common.Cpus.Executors;

namespace GameBoy.Emulators.Common.Cpus.Structs
{
    public struct Executor
    {
        public ulong LastCycles; // last cycle count
        public byte  Opcode;     // opcode to execute
        public byte  TempZ;      // temporary Z flag

        public Executor(byte opcode, ulong fetchCycles)
        {
            LastCycles = fetchCycles;
            Opcode = opcode;
            TempZ = default(byte);
        }

        public static void Execute(Cpu cpu)
        {
            // execute opcode
            switch (cpu.Reg.IR)
            {
                // 0
                case 0x00:
                    ExecutorSet._00(cpu);
                    break;
                case 0x01:
                    ExecutorSet._01(cpu);
                    break;
                case 0x02:
                    ExecutorSet._02(cpu);
                    break;
                case 0x03:
                    ExecutorSet._03(cpu);
                    break;
                case 0x04:
                    ExecutorSet._04(cpu);
                    break;
                case 0x05:
                    ExecutorSet._05(cpu);
                    break;
                case 0x06:
                    ExecutorSet._06(cpu);
                    break;
                case 0x07:
                    ExecutorSet._07(cpu);
                    break;
                case 0x08:
                    ExecutorSet._08(cpu);
                    break;
                case 0x09:
                    ExecutorSet._09(cpu);
                    break;
                case 0x0A:
                    ExecutorSet._0A(cpu);
                    break;
                case 0x0B:
                    ExecutorSet._0B(cpu);
                    break;
                case 0x0C:
                    ExecutorSet._0C(cpu);
                    break;
                case 0x0D:
                    ExecutorSet._0D(cpu);
                    break;
                case 0x0E:
                    ExecutorSet._0E(cpu);
                    break;
                case 0x0F:
                    ExecutorSet._0F(cpu);
                    break;
                // 1
                case 0x10:
                    ExecutorSet._10(cpu);
                    break;
                case 0x11:
                    ExecutorSet._11(cpu);
                    break;
                case 0x12:
                    ExecutorSet._12(cpu);
                    break;
                case 0x13:
                    ExecutorSet._13(cpu);
                    break;
                case 0x14:
                    ExecutorSet._14(cpu);
                    break;
                case 0x15:
                    ExecutorSet._15(cpu);
                    break;
                case 0x16:
                    ExecutorSet._16(cpu);
                    break;
                case 0x17:
                    ExecutorSet._17(cpu);
                    break;
                case 0x18:
                    ExecutorSet._18(cpu);
                    break;
                case 0x19:
                    ExecutorSet._19(cpu);
                    break;
                case 0x1A:
                    ExecutorSet._1A(cpu);
                    break;
                case 0x1B:
                    ExecutorSet._1B(cpu);
                    break;
                case 0x1C:
                    ExecutorSet._1C(cpu);
                    break;
                case 0x1D:
                    ExecutorSet._1D(cpu);
                    break;
                case 0x1E:
                    ExecutorSet._1E(cpu);
                    break;
                case 0x1F:
                    ExecutorSet._1F(cpu);
                    break;
                // 2
                case 0x20:
                    ExecutorSet._20(cpu);
                    break;
                case 0x21:
                    ExecutorSet._21(cpu);
                    break;
                case 0x22:
                    ExecutorSet._22(cpu);
                    break;
                case 0x23:
                    ExecutorSet._23(cpu);
                    break;
                case 0x24:
                    ExecutorSet._24(cpu);
                    break;
                case 0x25:
                    ExecutorSet._25(cpu);
                    break;
                case 0x26:
                    ExecutorSet._26(cpu);
                    break;
                case 0x27:
                    ExecutorSet._27(cpu);
                    break;
                case 0x28:
                    ExecutorSet._28(cpu);
                    break;
                case 0x29:
                    ExecutorSet._29(cpu);
                    break;
                case 0x2A:
                    ExecutorSet._2A(cpu);
                    break;
                case 0x2B:
                    ExecutorSet._2B(cpu);
                    break;
                case 0x2C:
                    ExecutorSet._2C(cpu);
                    break;
                case 0x2D:
                    ExecutorSet._2D(cpu);
                    break;
                case 0x2E:
                    ExecutorSet._2E(cpu);
                    break;
                case 0x2F:
                    ExecutorSet._2F(cpu);
                    break;
                // 3
                case 0x30:
                    ExecutorSet._30(cpu);
                    break;
                case 0x31:
                    ExecutorSet._31(cpu);
                    break;
                case 0x32:
                    ExecutorSet._32(cpu);
                    break;
                case 0x33:
                    ExecutorSet._33(cpu);
                    break;
                case 0x34:
                    ExecutorSet._34(cpu);
                    break;
                case 0x35:
                    ExecutorSet._35(cpu);
                    break;
                case 0x36:
                    ExecutorSet._36(cpu);
                    break;
                case 0x37:
                    ExecutorSet._37(cpu);
                    break;
                case 0x38:
                    ExecutorSet._38(cpu);
                    break;
                case 0x39:
                    ExecutorSet._39(cpu);
                    break;
                case 0x3A:
                    ExecutorSet._3A(cpu);
                    break;
                case 0x3B:
                    ExecutorSet._3B(cpu);
                    break;
                case 0x3C:
                    ExecutorSet._3C(cpu);
                    break;
                case 0x3D:
                    ExecutorSet._3D(cpu);
                    break;
                case 0x3E:
                    ExecutorSet._3E(cpu);
                    break;
                case 0x3F:
                    ExecutorSet._3F(cpu);
                    break;
                // 4
                case 0x40:
                    ExecutorSet._40(cpu);
                    break;
                case 0x41:
                    ExecutorSet._41(cpu);
                    break;
                case 0x42:
                    ExecutorSet._42(cpu);
                    break;
                case 0x43:
                    ExecutorSet._43(cpu);
                    break;
                case 0x44:
                    ExecutorSet._44(cpu);
                    break;
                case 0x45:
                    ExecutorSet._45(cpu);
                    break;
                case 0x46:
                    ExecutorSet._46(cpu);
                    break;
                case 0x47:
                    ExecutorSet._47(cpu);
                    break;
                case 0x48:
                    ExecutorSet._48(cpu);
                    break;
                case 0x49:
                    ExecutorSet._49(cpu);
                    break;
                case 0x4A:
                    ExecutorSet._4A(cpu);
                    break;
                case 0x4B:
                    ExecutorSet._4B(cpu);
                    break;
                case 0x4C:
                    ExecutorSet._4C(cpu);
                    break;
                case 0x4D:
                    ExecutorSet._4D(cpu);
                    break;
                case 0x4E:
                    ExecutorSet._4E(cpu);
                    break;
                case 0x4F:
                    ExecutorSet._4F(cpu);
                    break;
                // 5
                case 0x50:
                    ExecutorSet._50(cpu);
                    break;
                case 0x51:
                    ExecutorSet._51(cpu);
                    break;
                case 0x52:
                    ExecutorSet._52(cpu);
                    break;
                case 0x53:
                    ExecutorSet._53(cpu);
                    break;
                case 0x54:
                    ExecutorSet._54(cpu);
                    break;
                case 0x55:
                    ExecutorSet._55(cpu);
                    break;
                case 0x56:
                    ExecutorSet._56(cpu);
                    break;
                case 0x57:
                    ExecutorSet._57(cpu);
                    break;
                case 0x58:
                    ExecutorSet._58(cpu);
                    break;
                case 0x59:
                    ExecutorSet._59(cpu);
                    break;
                case 0x5A:
                    ExecutorSet._5A(cpu);
                    break;
                case 0x5B:
                    ExecutorSet._5B(cpu);
                    break;
                case 0x5C:
                    ExecutorSet._5C(cpu);
                    break;
                case 0x5D:
                    ExecutorSet._5D(cpu);
                    break;
                case 0x5E:
                    ExecutorSet._5E(cpu);
                    break;
                case 0x5F:
                    ExecutorSet._5F(cpu);
                    break;
                // 6
                case 0x60:
                    ExecutorSet._60(cpu);
                    break;
                case 0x61:
                    ExecutorSet._61(cpu);
                    break;
                case 0x62:
                    ExecutorSet._62(cpu);
                    break;
                case 0x63:
                    ExecutorSet._63(cpu);
                    break;
                case 0x64:
                    ExecutorSet._64(cpu);
                    break;
                case 0x65:
                    ExecutorSet._65(cpu);
                    break;
                case 0x66:
                    ExecutorSet._66(cpu);
                    break;
                case 0x67:
                    ExecutorSet._67(cpu);
                    break;
                case 0x68:
                    ExecutorSet._68(cpu);
                    break;
                case 0x69:
                    ExecutorSet._69(cpu);
                    break;
                case 0x6A:
                    ExecutorSet._6A(cpu);
                    break;
                case 0x6B:
                    ExecutorSet._6B(cpu);
                    break;
                case 0x6C:
                    ExecutorSet._6C(cpu);
                    break;
                case 0x6D:
                    ExecutorSet._6D(cpu);
                    break;
                case 0x6E:
                    ExecutorSet._6E(cpu);
                    break;
                case 0x6F:
                    ExecutorSet._6F(cpu);
                    break;
                // 7
                case 0x70:
                    ExecutorSet._70(cpu);
                    break;
                case 0x71:
                    ExecutorSet._71(cpu);
                    break;
                case 0x72:
                    ExecutorSet._72(cpu);
                    break;
                case 0x73:
                    ExecutorSet._73(cpu);
                    break;
                case 0x74:
                    ExecutorSet._74(cpu);
                    break;
                case 0x75:
                    ExecutorSet._75(cpu);
                    break;
                case 0x76:
                    ExecutorSet._76(cpu);
                    break;
                case 0x77:
                    ExecutorSet._77(cpu);
                    break;
                case 0x78:
                    ExecutorSet._78(cpu);
                    break;
                case 0x79:
                    ExecutorSet._79(cpu);
                    break;
                case 0x7A:
                    ExecutorSet._7A(cpu);
                    break;
                case 0x7B:
                    ExecutorSet._7B(cpu);
                    break;
                case 0x7C:
                    ExecutorSet._7C(cpu);
                    break;
                case 0x7D:
                    ExecutorSet._7D(cpu);
                    break;
                case 0x7E:
                    ExecutorSet._7E(cpu);
                    break;
                case 0x7F:
                    ExecutorSet._7F(cpu);
                    break;
                // 8
                case 0x80:
                    ExecutorSet._80(cpu);
                    break;
                case 0x81:
                    ExecutorSet._81(cpu);
                    break;
                case 0x82:
                    ExecutorSet._82(cpu);
                    break;
                case 0x83:
                    ExecutorSet._83(cpu);
                    break;
                case 0x84:
                    ExecutorSet._84(cpu);
                    break;
                case 0x85:
                    ExecutorSet._85(cpu);
                    break;
                case 0x86:
                    ExecutorSet._86(cpu);
                    break;
                case 0x87:
                    ExecutorSet._87(cpu);
                    break;
                case 0x88:
                    ExecutorSet._88(cpu);
                    break;
                case 0x89:
                    ExecutorSet._89(cpu);
                    break;
                case 0x8A:
                    ExecutorSet._8A(cpu);
                    break;
                case 0x8B:
                    ExecutorSet._8B(cpu);
                    break;
                case 0x8C:
                    ExecutorSet._8C(cpu);
                    break;
                case 0x8D:
                    ExecutorSet._8D(cpu);
                    break;
                case 0x8E:
                    ExecutorSet._8E(cpu);
                    break;
                case 0x8F:
                    ExecutorSet._8F(cpu);
                    break;
                // 9
                case 0x90:
                    ExecutorSet._90(cpu);
                    break;
                case 0x91:
                    ExecutorSet._91(cpu);
                    break;
                case 0x92:
                    ExecutorSet._92(cpu);
                    break;
                case 0x93:
                    ExecutorSet._93(cpu);
                    break;
                case 0x94:
                    ExecutorSet._94(cpu);
                    break;
                case 0x95:
                    ExecutorSet._95(cpu);
                    break;
                case 0x96:
                    ExecutorSet._96(cpu);
                    break;
                case 0x97:
                    ExecutorSet._97(cpu);
                    break;
                case 0x98:
                    ExecutorSet._98(cpu);
                    break;
                case 0x99:
                    ExecutorSet._99(cpu);
                    break;
                case 0x9A:
                    ExecutorSet._9A(cpu);
                    break;
                case 0x9B:
                    ExecutorSet._9B(cpu);
                    break;
                case 0x9C:
                    ExecutorSet._9C(cpu);
                    break;
                case 0x9D:
                    ExecutorSet._9D(cpu);
                    break;
                case 0x9E:
                    ExecutorSet._9E(cpu);
                    break;
                case 0x9F:
                    ExecutorSet._9F(cpu);
                    break;
                // A
                case 0xA0:
                    ExecutorSet._A0(cpu);
                    break;
                case 0xA1:
                    ExecutorSet._A1(cpu);
                    break;
                case 0xA2:
                    ExecutorSet._A2(cpu);
                    break;
                case 0xA3:
                    ExecutorSet._A3(cpu);
                    break;
                case 0xA4:
                    ExecutorSet._A4(cpu);
                    break;
                case 0xA5:
                    ExecutorSet._A5(cpu);
                    break;
                case 0xA6:
                    ExecutorSet._A6(cpu);
                    break;
                case 0xA7:
                    ExecutorSet._A7(cpu);
                    break;
                case 0xA8:
                    ExecutorSet._A8(cpu);
                    break;
                case 0xA9:
                    ExecutorSet._A9(cpu);
                    break;
                case 0xAA:
                    ExecutorSet._AA(cpu);
                    break;
                case 0xAB:
                    ExecutorSet._AB(cpu);
                    break;
                case 0xAC:
                    ExecutorSet._AC(cpu);
                    break;
                case 0xAD:
                    ExecutorSet._AD(cpu);
                    break;
                case 0xAE:
                    ExecutorSet._AE(cpu);
                    break;
                case 0xAF:
                    ExecutorSet._AF(cpu);
                    break;
                // B
                case 0xB0:
                    ExecutorSet._B0(cpu);
                    break;
                case 0xB1:
                    ExecutorSet._B1(cpu);
                    break;
                case 0xB2:
                    ExecutorSet._B2(cpu);
                    break;
                case 0xB3:
                    ExecutorSet._B3(cpu);
                    break;
                case 0xB4:
                    ExecutorSet._B4(cpu);
                    break;
                case 0xB5:
                    ExecutorSet._B5(cpu);
                    break;
                case 0xB6:
                    ExecutorSet._B6(cpu);
                    break;
                case 0xB7:
                    ExecutorSet._B7(cpu);
                    break;
                case 0xB8:
                    ExecutorSet._B8(cpu);
                    break;
                case 0xB9:
                    ExecutorSet._B9(cpu);
                    break;
                case 0xBA:
                    ExecutorSet._BA(cpu);
                    break;
                case 0xBB:
                    ExecutorSet._BB(cpu);
                    break;
                case 0xBC:
                    ExecutorSet._BC(cpu);
                    break;
                case 0xBD:
                    ExecutorSet._BD(cpu);
                    break;
                case 0xBE:
                    ExecutorSet._BE(cpu);
                    break;
                case 0xBF:
                    ExecutorSet._BF(cpu);
                    break;
                // C
                case 0xC0:
                    ExecutorSet._C0(cpu);
                    break;
                case 0xC1:
                    ExecutorSet._C1(cpu);
                    break;
                case 0xC2:
                    ExecutorSet._C2(cpu);
                    break;
                case 0xC3:
                    ExecutorSet._C3(cpu);
                    break;
                case 0xC4:
                    ExecutorSet._C4(cpu);
                    break;
                case 0xC5:
                    ExecutorSet._C5(cpu);
                    break;
                case 0xC6:
                    ExecutorSet._C6(cpu);
                    break;
                case 0xC7:
                    ExecutorSet._C7(cpu);
                    break;
                case 0xC8:
                    ExecutorSet._C8(cpu);
                    break;
                case 0xC9:
                    ExecutorSet._C9(cpu);
                    break;
                case 0xCA:
                    ExecutorSet._CA(cpu);
                    break;
                case 0xCB:
                    ExecutorSet._CB(cpu);
                    break;
                case 0xCC:
                    ExecutorSet._CC(cpu);
                    break;
                case 0xCD:
                    ExecutorSet._CD(cpu);
                    break;
                case 0xCE:
                    ExecutorSet._CE(cpu);
                    break;
                case 0xCF:
                    ExecutorSet._CF(cpu);
                    break;
                // D
                case 0xD0:
                    ExecutorSet._D0(cpu);
                    break;
                case 0xD1:
                    ExecutorSet._D1(cpu);
                    break;
                case 0xD2:
                    ExecutorSet._D2(cpu);
                    break;
                case 0xD3:
                    ExecutorSet._D3(cpu);
                    break;
                case 0xD4:
                    ExecutorSet._D4(cpu);
                    break;
                case 0xD5:
                    ExecutorSet._D5(cpu);
                    break;
                case 0xD6:
                    ExecutorSet._D6(cpu);
                    break;
                case 0xD7:
                    ExecutorSet._D7(cpu);
                    break;
                case 0xD8:
                    ExecutorSet._D8(cpu);
                    break;
                case 0xD9:
                    ExecutorSet._D9(cpu);
                    break;
                case 0xDA:
                    ExecutorSet._DA(cpu);
                    break;
                case 0xDB:
                    ExecutorSet._DB(cpu);
                    break;
                case 0xDC:
                    ExecutorSet._DC(cpu);
                    break;
                case 0xDD:
                    ExecutorSet._DD(cpu);
                    break;
                case 0xDE:
                    ExecutorSet._DE(cpu);
                    break;
                case 0xDF:
                    ExecutorSet._DF(cpu);
                    break;
                // E
                case 0xE0:
                    ExecutorSet._E0(cpu);
                    break;
                case 0xE1:
                    ExecutorSet._E1(cpu);
                    break;
                case 0xE2:
                    ExecutorSet._E2(cpu);
                    break;
                case 0xE3:
                    ExecutorSet._E3(cpu);
                    break;
                case 0xE4:
                    ExecutorSet._E4(cpu);
                    break;
                case 0xE5:
                    ExecutorSet._E5(cpu);
                    break;
                case 0xE6:
                    ExecutorSet._E6(cpu);
                    break;
                case 0xE7:
                    ExecutorSet._E7(cpu);
                    break;
                case 0xE8:
                    ExecutorSet._E8(cpu);
                    break;
                case 0xE9:
                    ExecutorSet._E9(cpu);
                    break;
                case 0xEA:
                    ExecutorSet._EA(cpu);
                    break;
                case 0xEB:
                    ExecutorSet._EB(cpu);
                    break;
                case 0xEC:
                    ExecutorSet._EC(cpu);
                    break;
                case 0xED:
                    ExecutorSet._ED(cpu);
                    break;
                case 0xEE:
                    ExecutorSet._EE(cpu);
                    break;
                case 0xEF:
                    ExecutorSet._EF(cpu);
                    break;
                // F
                case 0xF0:
                    ExecutorSet._F0(cpu);
                    break;
                case 0xF1:
                    ExecutorSet._F1(cpu);
                    break;
                case 0xF2:
                    ExecutorSet._F2(cpu);
                    break;
                case 0xF3:
                    ExecutorSet._F3(cpu);
                    break;
                case 0xF4:
                    ExecutorSet._F4(cpu);
                    break;
                case 0xF5:
                    ExecutorSet._F5(cpu);
                    break;
                case 0xF6:
                    ExecutorSet._F6(cpu);
                    break;
                case 0xF7:
                    ExecutorSet._F7(cpu);
                    break;
                case 0xF8:
                    ExecutorSet._F8(cpu);
                    break;
                case 0xF9:
                    ExecutorSet._F9(cpu);
                    break;
                case 0xFA:
                    ExecutorSet._FA(cpu);
                    break;
                case 0xFB:
                    ExecutorSet._FB(cpu);
                    break;
                case 0xFC:
                    ExecutorSet._FC(cpu);
                    break;
                case 0xFD:
                    ExecutorSet._FD(cpu);
                    break;
                case 0xFE:
                    ExecutorSet._FE(cpu);
                    break;
                case 0xFF:
                    ExecutorSet._FF(cpu);
                    break;
                default: throw new Exception("Invalid opcode");
            }

            // last
            // cpu.ClockCounter += 4;
            // LastCycles -= 1;
            // return LastCycles <= 1;
        }
    }
}