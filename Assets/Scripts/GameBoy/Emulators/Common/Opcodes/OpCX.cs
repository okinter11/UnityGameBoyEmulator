namespace GameBoy.Emulators.Common.Opcodes
{
    public class OpCX
    {
        public static void XCB_PREFIX(Cpu cpu)
        {
            byte opcode = Op.Read(cpu, cpu.ProgramCounter + 1);
            byte opBit = (byte)((opcode & 0xF8) >> 5);
            byte opReg = (byte)(opcode & 0x07);
            ref byte opRef = ref cpu.Reg.A;
            Op.GetRegister(cpu, opReg, ref opRef);
            Op.CbOperation(cpu, opBit, ref opRef);
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
            if (!cpu.Reg.z)
            {
                cpu.CallStack.Push(cpu.ProgramCounter);
                ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
                cpu.ProgramCounter = address;
                cpu.ClockCounter += 24;
            }
            else
            {
                cpu.ProgramCounter += 3;
                cpu.ClockCounter += 12;
            }
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

        public static void XCD_CALL_A16(Cpu cpu)
        {
            cpu.CallStack.Push(cpu.ProgramCounter);
            ushort address = Op.Read16(cpu, cpu.ProgramCounter + 1);
            cpu.ProgramCounter = address;
            cpu.ClockCounter += 24;
        }
    }
}