namespace GameBoy.Emulators.Common.Opcodes
{
    public static class OpEX
    {
        public static void XE0_LDH_A8_A(Cpu cpu)
        {
            byte address = Op.Read(cpu, cpu.ProgramCounter + 1);
            Op.Write(cpu, Ram.MAP_IO_REGISTERS + address, cpu.Reg.A);
            cpu.ProgramCounter += 2;
            cpu.ClockCounter += 12;
        }
    }
}