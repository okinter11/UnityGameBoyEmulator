using System.Collections.Generic;
using GameBoy.Emulators.Common.Opcodes;

namespace GameBoy.Emulators.Common.Cpus
{
    public class Serial
    {
        /// <summary>
        ///     0xFF01
        /// </summary>
        public byte sb;
        /// <summary>
        ///     0xFF02
        /// </summary>
        public byte sc;

        private bool transferring;

        private Queue<byte> output_buffer;

        private byte out_byte;

        private sbyte transfer_bit;

        public bool IsMaster       => Valid.BitTest(sc, 0);
        public bool TransferEnable => Valid.BitTest(sc, 7);

        public Serial()
        {
            sb = 0xFF;
            sc = 0x7C;
            transferring = false;
        }

        public void BeginTransfer()
        {
            transferring = true;
            out_byte = sb;
            transfer_bit = 7;
        }

        public void EndTransfer(Cpu cpu)
        {
            output_buffer.Enqueue(out_byte);
            Valid.BitReset(ref sc, 7);
            transferring = false;
            cpu._intFlags |= CpuOp.INT_SERIAL;
        }

        public void ProcessTransfer(Cpu cpu)
        {
            sb <<= 1;
            sb += 1;
            transfer_bit -= 1;
            if (transfer_bit < 0)
            {
                transfer_bit = 0;
                EndTransfer(cpu);
            }
        }

        public static void Tick(Cpu cpu)
        {
            if (!cpu.Serial.transferring && cpu.Serial.TransferEnable && cpu.Serial.IsMaster)
            {
                cpu.Serial.BeginTransfer();
            }
            else if (cpu.Serial.transferring)
            {
                cpu.Serial.ProcessTransfer(cpu);
            }
        }
    }
}