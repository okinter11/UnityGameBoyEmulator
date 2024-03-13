using System.Collections.Generic;
using GameBoy.Emulators.Common.Cpus.Structs;

namespace GameBoy.Emulators.Common.Cpus
{
    public class FetchExecuteSchedule
    {
        public void Tick()
        {
        }

        #region Init

        public FetchExecuteSchedule(Cpu cpu)
        {
            _cpu = cpu;
            _registers = new CpuRegister();
            _executorList = new Queue<Executor>();
        }

        private Cpu             _cpu;
        private CpuRegister     _registers;
        private Queue<Executor> _executorList;

        #endregion
    }
}