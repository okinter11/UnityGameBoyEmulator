namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op3X
    {
        public static void X3E_LD_A_N8(Cpu cpu)
        {
            cpu.Reg.A = cpu.Ram[cpu.ProgramCounter + 1];
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 8;
        }
    }
}