using System;

namespace GameBoy.Emulators.Common.Cpus.Structs
{
    public struct Executor
    {
        public ulong FetchCycles; // fetch opcode time in cycles
        public byte  Opcode;      // opcode to execute

        public Executor(ulong fetchCycles, byte opcode)
        {
            FetchCycles = fetchCycles;
            Opcode = opcode;
        }

        public void Execute(Cpu cpu)
        {
            throw new NotImplementedException();
        }

        public void LateExecute(Cpu cpu)
        {
            throw new NotImplementedException();
        }
    }
}