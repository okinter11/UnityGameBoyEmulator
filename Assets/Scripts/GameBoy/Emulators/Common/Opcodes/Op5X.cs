namespace GameBoy.Emulators.Common.Opcodes
{
    public static class Op5X
    {
        public static void X50_LD_D_B(Cpu cpu)
        {
            cpu.Reg.D = cpu.Reg.B;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}