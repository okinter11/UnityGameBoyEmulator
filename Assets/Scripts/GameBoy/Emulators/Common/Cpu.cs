using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GameBoy.Emulators.Common
{
    public sealed class Cpu
    {
        /// <summary>
        ///     Clock speed of the GameBoy
        ///     https://gbdev.io/pandocs/Specifications.html
        /// </summary>
        public const ulong CLOCK_SPEED = 4194304;

        #region RAM

        public readonly Ram Ram = new();

        #endregion

        private bool          _ime;
        public  Stack<ushort> CallStack = new();
        /// <summary>
        ///     Clock counter
        /// </summary>
        public ulong ClockCounter;

        public bool Halted;

        /// <summary>
        ///     CPU Registers
        /// </summary>
        public GameBoyEmulatorCpuRegister Reg = default(GameBoyEmulatorCpuRegister);
        public bool IME
        {
            get => throw new Exception("Interrupt Master Enable cannot be read");
            set => _ime = value;
        }

        /// <summary>
        ///     GameBoy Emulator CPU Registers Program Counter
        /// </summary>
        public ushort ProgramCounter
        {
            get => Reg.PC;
            set => Reg.PC = value;
        }

        /// <summary>
        ///     GameBoy Emulator CPU Registers
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct GameBoyEmulatorCpuRegister
        {
            /// <summary>
            ///     Accumulator & Flags
            /// </summary>
            [FieldOffset(0)] public ushort AF;
            /// <summary>
            ///     Accumulator
            /// </summary>
            [FieldOffset(0)] public byte A;
            /// <summary>
            ///     Flags
            /// </summary>
            [FieldOffset(1)] public byte F;
            [FieldOffset(2)] public ushort BC;
            [FieldOffset(2)] public byte   B;
            [FieldOffset(3)] public byte   C;
            [FieldOffset(4)] public ushort DE;
            [FieldOffset(4)] public byte   D;
            [FieldOffset(5)] public byte   E;
            [FieldOffset(6)] public ushort HL;
            [FieldOffset(6)] public byte   H;
            [FieldOffset(7)] public byte   L;
            /// <summary>
            ///     Stack Pointer
            /// </summary>
            [FieldOffset(8)] public ushort SP;
            /// <summary>
            ///     Program Counter
            /// </summary>
            [FieldOffset(10)] public ushort PC;

            /// <summary>
            ///     Zero Flag
            /// </summary>
            public bool z
            {
                get => (F & 0b10000000) != 0;
                set => F = (byte)(value ? F | 0b10000000 : F & 0b01111111);
            }

            /// <summary>
            ///     Subtraction flag (BCD)
            /// </summary>
            public bool n
            {
                get => (F & 0b01000000) != 0;
                set => F = (byte)(value ? F | 0b01000000 : F & 0b10111111);
            }

            /// <summary>
            ///     Half Carry flag (BCD)
            /// </summary>
            public bool h
            {
                get => (F & 0b00100000) != 0;
                set => F = (byte)(value ? F | 0b00100000 : F & 0b11011111);
            }

            /// <summary>
            ///     Carry flag
            /// </summary>
            public bool c
            {
                get => (F & 0b00010000) != 0;
                set => F = (byte)(value ? F | 0b00010000 : F & 0b11101111);
            }
        }

        #region CPU Method

        public Cpu()
        {
            Init();
        }

        public void Init()
        {
            Reg.AF = 0x01B0;
            Reg.BC = 0x0013;
            Reg.DE = 0x00D8;
            Reg.HL = 0x014D;
            ProgramCounter = 0x0100;
            Reg.SP = 0xFFFE;
            Halted = false;
        }

        public void Tick(byte ticks)
        {
            ProgramCounter += ticks;
            ClockCounter += ticks * 4UL;
        }

        public void EnableInterruptMaster()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ROM

        private byte[] _romData = Array.Empty<byte>();

        public byte[] RomData
        {
            get => _romData;
            set
            {
                _romData = value;
                Ram.LoadRom(value);
            }
        }

        #endregion

        #region Graphics

        public const ushort SCREEN_WIDTH  = 160;
        public const ushort SCREEN_HEIGHT = 144;

        #endregion
    }
}