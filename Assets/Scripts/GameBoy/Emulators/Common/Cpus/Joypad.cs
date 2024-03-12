namespace GameBoy.Emulators.Common.Cpus
{
    public class Joypad
    {
        public bool a;
        public bool b;
        public bool down;
        public bool left;

        #region P1

        public byte p1; // 0xFF00

        #endregion

        public bool right;
        public bool select;
        public bool start;
        public bool up;

        public Joypad() => p1 = 0xFF;
    }
}