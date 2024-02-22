using System;

namespace GameBoy.Emulators.Common
{
    public sealed class Ram
    {
        public const     ushort MAX_SIZE = ushort.MaxValue;
        private readonly byte[] Data     = new byte[MAX_SIZE];

        public byte this[int address]
        {
            get
            {
                if (address >= 0 && MAX_SIZE > address)
                {
                    return Data[address];
                }
                else
                {
                    return 0xFF;
                }
            }
            set
            {
                if (address >= 0 && MAX_SIZE > address)
                {
                    Data[address] = value;
                }
            }
        }
        public byte this[ushort address]
        {
            get => Data[address];
            set => Data[address] = value;
        }

        public void LoadRom(in byte[] romData)
        {
            if (romData == null)
            {
                throw new Exception("ROM数据为空");
            }

            if (romData.Length < MAP_ROM_BANK_0_END + 1)
            {
                throw new Exception("ROM容量不足");
            }

            Array.Copy(romData, Data, MAP_ROM_BANK_0_END + 1);
        }

        #region MemoryMap

        public const ushort MAP_ROM_BANK_0       = 0x0000;
        public const ushort MAP_ROM_BANK_0_END   = 0x3FFF;
        public const ushort MAP_ROM_BANK_1       = 0x4000;
        public const ushort MAP_ROM_BANK_1_END   = 0x7FFF;
        public const ushort MAP_VRAM             = 0x8000;
        public const ushort MAP_VRAM_END         = 0x9FFF;
        public const ushort MAP_EXTERNAL_RAM     = 0xA000;
        public const ushort MAP_EXTERNAL_RAM_END = 0xBFFF;
        public const ushort MAP_WORK_RAM         = 0xC000;
        public const ushort MAP_WORK_RAM_END     = 0xDFFF;
        public const ushort MAP_ECHO_RAM         = 0xE000;
        public const ushort MAP_ECHO_RAM_END     = 0xFDFF;
        public const ushort MAP_OAM              = 0xFE00;
        public const ushort MAP_OAM_END          = 0xFE9F;
        public const ushort MAP_UNUSED           = 0xFEA0;
        public const ushort MAP_UNUSED_END       = 0xFEFF;
        public const ushort MAP_IO_REGISTERS     = 0xFF00;
        public const ushort MAP_IO_REGISTERS_END = 0xFF7F;
        public const ushort MAP_HRAM             = 0xFF80;
        public const ushort MAP_HRAM_END         = 0xFFFE;
        public const ushort MAP_INTERRUPT_ENABLE = 0xFFFF;

        #endregion
    }
}