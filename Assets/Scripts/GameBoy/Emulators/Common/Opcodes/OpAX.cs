namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpAX
    {
        public static void XAF_XOR_A_A(Cpu cpu)
        {
            cpu.Reg.A = 0;
            cpu.Reg.z = true;
            cpu.Reg.n = false;
            cpu.Reg.h = false;
            cpu.Reg.c = false;
            cpu.ProgramCounter += 1;
            cpu.ClockCounter += 4;
        }
    }
}