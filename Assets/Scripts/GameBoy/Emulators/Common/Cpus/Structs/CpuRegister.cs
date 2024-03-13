using System.Runtime.InteropServices;

namespace GameBoy.Emulators.Common.Cpus.Structs
{
    /// <summary>
    ///     GameBoy Emulator CPU Registers
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CpuRegister
    {
        /// <summary>
        ///     Interrupt Register
        /// </summary>
        [FieldOffset(0)] public byte IR;
        /// <summary>
        ///     Interrupt Enable
        /// </summary>
        [FieldOffset(1)] public byte IE;
        /// <summary>
        ///     Accumulator & Flags
        /// </summary>
        [FieldOffset(2)] public ushort AF;
        /// <summary>
        ///     Accumulator
        /// </summary>
        [FieldOffset(2)] public byte A;
        /// <summary>
        ///     Flags
        /// </summary>
        [FieldOffset(3)] public byte F;
        [FieldOffset(4)] public ushort BC;
        [FieldOffset(4)] public byte   B;
        [FieldOffset(5)] public byte   C;
        [FieldOffset(6)] public ushort DE;
        [FieldOffset(6)] public byte   D;
        [FieldOffset(7)] public byte   E;
        [FieldOffset(8)] public ushort HL;
        [FieldOffset(8)] public byte   H;
        [FieldOffset(9)] public byte   L;
        /// <summary>
        ///     Program Counter
        /// </summary>
        [FieldOffset(10)] public ushort PC;
        /// <summary>
        ///     Stack Pointer
        /// </summary>
        [FieldOffset(12)] public ushort SP;

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