using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GameBoy.Emulators.Common
{
    public sealed class Cpu
    {
        /// <summary>
        ///     Clock speed of the GameBoy
        /// </summary>
        public const ulong CLOCK_SPEED = 4194304;
        public Stack<ushort> CallStack = new();
        /// <summary>
        ///     Clock counter
        /// </summary>
        public ulong ClockCounter;

        public GameBoyEmulatorCpuRegister Registers = default(GameBoyEmulatorCpuRegister);
        public byte[]                     RomData   = Array.Empty<byte>();

        /// <summary>
        ///     GameBoy Emulator CPU Registers Program Counter
        /// </summary>
        public ushort ProgramCounter
        {
            get => Registers.PC;
            set => Registers.PC = value;
        }

        /// <summary>
        ///     GameBoy Emulator CPU Registers
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct GameBoyEmulatorCpuRegister
        {
            // public void ADC(ref byte left, byte right)
            // {
            //     c = DetectOverflow(left, right);
            //     h = DetectHalfOverflow(left, right);
            //     left += right;
            //     z = left == 0;
            //     n = false;
            // }
            //
            // public void ADD(ref byte left, byte right)
            // {
            //     c = DetectOverflow(left, right);
            //     h = DetectHalfOverflow(left, right);
            //     left += right;
            //     z = left == 0;
            //     n = false;
            // }
            //
            // public void AND(byte left, byte right)
            // {
            //     z = (left & right) == 0;
            //     n = false;
            //     h = true;
            //     c = false;
            // }
            //
            // public static bool DetectHalfOverflow(byte left, byte right) => (left & 0x0F) + (right & 0x0F) > 0x0F;
            //
            // public static bool DetectOverflow(byte left, byte right) => left + right > 0xFF;

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
    }
}