using GameBoy.Emulators.Common.Opcodes;

namespace GameBoy.Emulators.Common.Cpus
{
    public class Joypad
    {
        #region P1

        public byte p1; // 0xFF00

        #endregion

        public Joypad() => p1 = 0xFF;

        public static void JoypadTick(Cpu cpu)
        {
            byte v = cpu.Joypad.GetKeyState();
            byte p1 = cpu.Joypad.p1;
            if (((p1 & (1 << 0)) != 0 && (v & (1 << 0)) == 0)
             || ((p1 & (1 << 1)) != 0 && (v & (1 << 1)) == 0)
             || ((p1 & (1 << 2)) != 0 && (v & (1 << 2)) == 0)
             || ((p1 & (1 << 3)) != 0 && (v & (1 << 3)) == 0))
            {
                cpu._intFlags |= CpuOp.INT_JOYPAD;
            }

            cpu.Joypad.p1 = v;
        }

        public byte GetKeyState()
        {
            byte v = 0xFF;
            if ((p1 & (1 << 4)) == 0)
            {
                if (right)
                {
                    v = (byte)(v & ~(1 << 0));
                }

                if (left)
                {
                    v = (byte)(v & ~(1 << 1));
                }

                if (up)
                {
                    v = (byte)(v & ~(1 << 2));
                }

                if (down)
                {
                    v = (byte)(v & ~(1 << 3));
                }

                v = (byte)(v & ~(1 << 4));
            }
            else if ((p1 & (1 << 5)) == 0)
            {
                if (a)
                {
                    v = (byte)(v & ~(1 << 0));
                }

                if (b)
                {
                    v = (byte)(v & ~(1 << 1));
                }

                if (select)
                {
                    v = (byte)(v & ~(1 << 2));
                }

                if (start)
                {
                    v = (byte)(v & ~(1 << 3));
                }

                v = (byte)(v & ~(1 << 5));
            }

            return v;
        }

        #region Menu

        public bool select;
        public bool start;

        #endregion

        #region Control

        public bool a;
        public bool b;
        public bool down;
        public bool left;
        public bool right;
        public bool up;

        #endregion
    }
}