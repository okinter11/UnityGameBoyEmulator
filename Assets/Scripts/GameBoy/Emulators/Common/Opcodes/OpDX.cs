namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpDX
    {
        public static void XD2_JP_NC_A16(Cpu cpu)
        {
            if (!cpu.Reg.c)
            {
                cpu.ProgramCounter = Op.Read16(cpu, cpu.ProgramCounter);
                cpu.ClockCounter += 16;
            }
            else
            {
                cpu.ProgramCounter += 3;
                cpu.ClockCounter += 12;
            }
        }
        
        public static void XDA_JP_C_A16(Cpu cpu)
        {
            if (cpu.Reg.c)
            {
                cpu.ProgramCounter = Op.Read16(cpu, cpu.ProgramCounter);
                cpu.ClockCounter += 16;
            }
            else
            {
                cpu.ProgramCounter += 3;
                cpu.ClockCounter += 12;
            }
        }
    }
}